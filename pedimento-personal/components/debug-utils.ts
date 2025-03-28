// Utilidades para depuración de fechas y otros valores

// Actualizar la función formatDateForDisplay para usar undefined en lugar de null
export function formatDateForDisplay(dateString: string | undefined): string {
  if (!dateString) return "N/A";

  try {
    const date = new Date(dateString);

    // Verificar si la fecha es válida
    if (isNaN(date.getTime())) {
      return "Fecha inválida";
    }

    // Formatear como DD/MM/YYYY
    return date.toLocaleDateString("es-ES", {
      day: "2-digit",
      month: "2-digit",
      year: "numeric",
    });
  } catch (error) {
    console.error("Error al formatear fecha:", error);
    return "Error de formato";
  }
}

// Actualizar la función parseLocalDate para usar undefined en lugar de null
export function parseLocalDate(dateString: string): Date | undefined {
  if (!dateString) return undefined;

  try {
    // Asumiendo que dateString está en formato YYYY-MM-DD (formato HTML5 input date)
    const [year, month, day] = dateString.split("-").map(Number);

    // Crear fecha en zona horaria local (sin ajuste UTC)
    const date = new Date(year, month - 1, day);

    return date;
  } catch (error) {
    console.error("Error al parsear fecha local:", error);
    return undefined;
  }
}

export function debugDate(label: string, dateValue: any): void {
  console.log(`DEBUG ${label}:`, {
    original: dateValue,
    type: typeof dateValue,
    asDate: dateValue ? new Date(dateValue) : undefined,
    asISOString: dateValue ? new Date(dateValue).toISOString() : undefined,
    asLocaleDateString: dateValue
      ? new Date(dateValue).toLocaleDateString()
      : undefined,
  });
}

// Función para depurar objetos de parámetros
export function debugParams(params: Record<string, any>): void {
  console.log("Parámetros de la solicitud:", params);

  // Depurar cada parámetro individualmente
  Object.entries(params).forEach(([key, value]) => {
    console.log(`Parámetro ${key}:`, {
      value,
      type: typeof value,
      isUndefined: value === undefined,
      isNull: value === null,
      isEmpty: value === "",
    });

    // Depuración especial para fechas
    if (key.toLowerCase().includes("fecha") && value) {
      debugDate(`${key} como fecha`, value);
    }
  });
}
