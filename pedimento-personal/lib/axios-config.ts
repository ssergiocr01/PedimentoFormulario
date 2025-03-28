import axios from "axios";

// Configurar axios para ignorar errores de certificado SSL en desarrollo
// Esto puede ser necesario si estás usando HTTPS localmente con certificados autofirmados
if (process.env.NODE_ENV === "development") {
  process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
}

// Configuración global de axios
axios.defaults.headers.common["Accept"] = "application/json";
axios.defaults.headers.common["Content-Type"] = "application/json";
axios.defaults.timeout = 10000; // 10 segundos

export default axios;
