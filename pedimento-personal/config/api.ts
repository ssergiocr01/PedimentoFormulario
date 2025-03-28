// Asegúrate de que esta URL sea correcta y accesible desde el navegador
export const API_BASE_URL = "https://localhost:7152/api";

// Configuración global para axios
export const API_CONFIG = {
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
  timeout: 30000, // Aumentado de 10000 a 30000 (30 segundos)
};
