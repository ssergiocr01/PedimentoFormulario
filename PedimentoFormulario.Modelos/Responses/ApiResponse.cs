using System;

namespace PedimentoFormulario.Modelos.Response
{
    /// <summary>
    /// Clase genérica para estandarizar las respuestas de la API
    /// </summary>
    /// <typeparam name="T">Tipo de datos que contiene la respuesta</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indica si la operación fue exitosa
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje descriptivo de la operación
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Datos retornados por la operación
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Código de error en caso de fallo
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Timestamp de la respuesta
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ApiResponse()
        {
        }

        /// <summary>
        /// Constructor para respuestas exitosas con datos
        /// </summary>
        /// <param name="data">Datos a retornar</param>
        /// <param name="message">Mensaje descriptivo</param>
        public ApiResponse(T data, string message = "Operación completada con éxito")
        {
            Success = true;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Constructor para respuestas de error
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        /// <param name="errorCode">Código de error</param>
        public ApiResponse(string message, string errorCode = null)
        {
            Success = false;
            Message = message;
            ErrorCode = errorCode;
            Data = default;
        }

        /// <summary>
        /// Crea una respuesta exitosa
        /// </summary>
        /// <param name="data">Datos a retornar</param>
        /// <param name="message">Mensaje descriptivo</param>
        /// <returns>Instancia de ApiResponse con éxito</returns>
        public static ApiResponse<T> Ok(T data, string message = "Operación completada con éxito")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// Crea una respuesta de error
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        /// <param name="errorCode">Código de error</param>
        /// <returns>Instancia de ApiResponse con error</returns>
        public static ApiResponse<T> Error(string message, string errorCode = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                ErrorCode = errorCode,
                Data = default
            };
        }
    }

    /// <summary>
    /// Versión no genérica de ApiResponse para respuestas sin datos
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Indica si la operación fue exitosa
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje descriptivo de la operación
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Código de error en caso de fallo
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Timestamp de la respuesta
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ApiResponse()
        {
        }

        /// <summary>
        /// Constructor para respuestas exitosas
        /// </summary>
        /// <param name="message">Mensaje descriptivo</param>
        public ApiResponse(string message = "Operación completada con éxito")
        {
            Success = true;
            Message = message;
        }

        /// <summary>
        /// Constructor para respuestas de error
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        /// <param name="errorCode">Código de error</param>
        public ApiResponse(string message, string errorCode)
        {
            Success = false;
            Message = message;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Crea una respuesta exitosa
        /// </summary>
        /// <param name="message">Mensaje descriptivo</param>
        /// <returns>Instancia de ApiResponse con éxito</returns>
        public static ApiResponse Ok(string message = "Operación completada con éxito")
        {
            return new ApiResponse
            {
                Success = true,
                Message = message
            };
        }

        /// <summary>
        /// Crea una respuesta de error
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        /// <param name="errorCode">Código de error</param>
        /// <returns>Instancia de ApiResponse con error</returns>
        public static ApiResponse Error(string message, string errorCode = null)
        {
            return new ApiResponse
            {
                Success = false,
                Message = message,
                ErrorCode = errorCode
            };
        }
    }
}

