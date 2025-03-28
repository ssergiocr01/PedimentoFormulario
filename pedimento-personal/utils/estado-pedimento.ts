// Mapeo de códigos de estado a descripciones
export const ESTADOS_PEDIMENTO: Record<number, string> = {
  0: "ANULADO",
  1: "EN CONFECCION",
  2: "FIRMADO POR JEFE DE ORH",
  3: "FIRMADO POR JEFE DE UNIDAD",
  4: "ENVIADO A SERVICIO CIVIL",
  5: "FIRMADO POR SERVICIO CIVIL",
  6: "DEVUELTA A LA ORH",
  7: "RECIBIDO POR SERVICIO CIVIL",
  8: "PARA NOMINA",
  9: "CON PROPUESTA PARA CONCURSO INTERNO",
  10: "PARA CONCURSO EXTERNO",
  11: "PARA ARTICULO 15, PARRAFO 3RO",
  12: "EN PROCESO DE ANULACÓN",
  13: "EN PROCESO DE REACTIVACION",
  14: "EN PROCESO DE MODIFICACION",
  15: "EN NOMINA",
  16: "EN CONCURSO",
  17: "MODIFICANDOSE POR LA ORH",
  18: "EN PROCESO EN ESPERA",
  19: "EN ESPERA",
  20: "RESUELTO",
  21: "REACTIVADO",
  22: "MIGRACION_en_PROCESO",
  23: "NOMBRAMIENTO FORMALIZADO",
  24: "EN PROCESO DE RESERVA/LIBERACIÓN DISCAPACIDAD",
  25: "RESERVANDO/LIBERANDO DISCAPACIDAD",
  26: "RESUELTO POR CONCURSO INTERNO",
  27: "SIN PROPUESTA PARA CONCURSO INTERNO",
  28: "PARA RESOLUCIÓN TRANSITORIO IX MEP, DG-RES-88-2023",
  29: "NO RESUELTO EN EL CONCURSO INTERNO",
  30: "RESUELTO POR TRANSITORIO IX LMEP",
  31: "NO RESUELTO POR TRANSITORIO IX LMEP",
};

// Función para obtener la descripción del estado
export function getEstadoDescripcion(codigo: number | undefined): string {
  if (codigo === undefined || codigo === null) {
    return "DESCONOCIDO";
  }
  return ESTADOS_PEDIMENTO[codigo] || "DESCONOCIDO";
}

// Función para obtener el color del estado, optimizada para los estados que se mostrarán
// Usando solo colores que sabemos que funcionan: azul, verde, amarillo
export function getEstadoColor(codigo: number | undefined): string {
  console.log(`getEstadoColor llamado con código: ${codigo}`);
  if (codigo === undefined || codigo === null) {
    return "bg-gray-100 text-gray-800"; // Valor por defecto
  }

  // Mapeo de estados específicos a colores que sabemos que funcionan
  switch (codigo) {
    case 1: // EN CONFECCION
    case 17: // MODIFICANDOSE POR LA ORH
      return "bg-blue-100 text-blue-800";

    case 2: // FIRMADO POR JEFE DE ORH
    case 3: // FIRMADO POR JEFE DE UNIDAD
    case 4: // ENVIADO A SERVICIO CIVIL
    case 7: // RECIBIDO POR SERVICIO CIVIL
      // Usar azul más oscuro en lugar de indigo/purple/violet
      return "bg-blue-200 text-blue-900";

    case 5: // FIRMADO POR SERVICIO CIVIL
      return "bg-green-100 text-green-800";

    case 6: // DEVUELTA A LA ORH
      // Usar amarillo más oscuro en lugar de naranja
      return "bg-yellow-200 text-yellow-900";

    case 8: // PARA NOMINA
    case 9: // CON PROPUESTA PARA CONCURSO INTERNO
    case 10: // PARA CONCURSO EXTERNO
      return "bg-yellow-100 text-yellow-800";

    case 21: // REACTIVADO
    case 25: // RESERVANDO/LIBERANDO DISCAPACIDAD
      // Usar azul claro en lugar de indigo/sky
      return "bg-blue-50 text-blue-700";

    default:
      return "bg-gray-100 text-gray-800";
  }
}
