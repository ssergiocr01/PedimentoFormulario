using System.Net;

namespace PedimentoFormulario.Modelos.Responses
{
    /// <summary>
    /// Clase genérica para estandarizar las respuestas de la API
    /// </summary>
    /// <typeparam name="T">Tipo de datos que se devolverá en la respuesta</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indica si la operación fue exitosa
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje descriptivo del resultado de la operación
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Datos devueltos por la operación
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Código de estado HTTP
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Lista de errores en caso de que la operación falle
        /// </summary>
        public List<string> Errors { get; set; } = new List<string>();

        /// <summary>
        /// Constructor para respuesta exitosa con datos
        /// </summary>
        public static ApiResponse<T> SuccessResponse(T data, string message = "Operación realizada con éxito")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Constructor para respuesta exitosa sin datos (por ejemplo, para operaciones de eliminación)
        /// </summary>
        public static ApiResponse<T> SuccessResponse(string message = "Operación realizada con éxito")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                StatusCode = HttpStatusCode.OK
            };
        }

        /// <summary>
        /// Constructor para respuesta de creación exitosa
        /// </summary>
        public static ApiResponse<T> CreatedResponse(T data, string message = "Recurso creado con éxito")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = HttpStatusCode.Created
            };
        }

        /// <summary>
        /// Constructor para respuesta de error
        /// </summary>
        public static ApiResponse<T> ErrorResponse(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode
            };
        }

        /// <summary>
        /// Constructor para respuesta de error con lista de errores
        /// </summary>
        public static ApiResponse<T> ErrorResponse(List<string> errors, string message = "Se han producido uno o más errores", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors,
                StatusCode = statusCode
            };
        }

        /// <summary>
        /// Constructor para respuesta de error de validación
        /// </summary>
        public static ApiResponse<T> ValidationErrorResponse(List<string> errors)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = "Error de validación",
                Errors = errors,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        /// <summary>
        /// Constructor para respuesta de recurso no encontrado
        /// </summary>
        public static ApiResponse<T> NotFoundResponse(string message = "Recurso no encontrado")
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = HttpStatusCode.NotFound
            };
        }

        /// <summary>
        /// Constructor para respuesta de error interno del servidor
        /// </summary>
        public static ApiResponse<T> ServerErrorResponse(Exception ex)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = "Error interno del servidor",
                Errors = new List<string> { ex.Message },
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }
}