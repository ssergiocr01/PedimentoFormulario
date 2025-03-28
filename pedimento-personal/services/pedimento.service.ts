import axios from "axios";
import { API_BASE_URL, API_CONFIG } from "@/config/api";
import {
  type ApiResponse,
  type PedimentoAPI,
  type Pedimento,
  mapApiToPedimento,
} from "@/types/pedimento";

export async function getPedimentos(): Promise<Pedimento[]> {
  try {
    // Agregar un mensaje de log para depuración
    console.log(
      "Iniciando solicitud de pedimentos a:",
      `${API_BASE_URL}/Pedimentos`
    );

    const response = await axios.get<ApiResponse<PedimentoAPI[]>>(
      `${API_BASE_URL}/Pedimentos`,
      {
        ...API_CONFIG,
        // Asegurarse de que se aplica el timeout
        timeout: API_CONFIG.timeout,
      }
    );

    console.log("Respuesta recibida:", response.status);

    if (response.data.success && Array.isArray(response.data.data)) {
      // Mapear los datos de la API al formato que espera nuestra aplicación
      return response.data.data.map(mapApiToPedimento);
    } else {
      console.error("Error en la respuesta de la API:", response.data);
      throw new Error(
        response.data.message || "Error al obtener los pedimentos"
      );
    }
  } catch (error: any) {
    console.error("Error al cargar los pedimentos:", error);

    // Mensaje de error más descriptivo
    let errorMessage = "Error desconocido al cargar los pedimentos";

    if (error.code === "ECONNABORTED") {
      errorMessage =
        "La solicitud ha excedido el tiempo de espera. Por favor, inténtelo de nuevo más tarde.";
    } else if (error.response) {
      // El servidor respondió con un código de estado fuera del rango 2xx
      console.error("Datos de error:", error.response.data);
      console.error("Estado de error:", error.response.status);
      errorMessage = `Error del servidor: ${error.response.status} - ${
        error.response.data?.message || "Sin mensaje"
      }`;
    } else if (error.request) {
      // La solicitud se realizó pero no se recibió respuesta
      console.error("Solicitud sin respuesta:", error.request);
      errorMessage =
        "No se recibió respuesta del servidor. Verifique su conexión a internet o inténtelo más tarde.";
    } else {
      // Algo ocurrió al configurar la solicitud que desencadenó un error
      console.error("Error de configuración:", error.message);
      errorMessage = `Error: ${error.message}`;
    }

    throw new Error(errorMessage);
  }
}
