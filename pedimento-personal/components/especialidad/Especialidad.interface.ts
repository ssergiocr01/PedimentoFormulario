export interface Especialidad {
  codEspecialidad: number;
  nombreEspecialidad: string;
  activo?: boolean;
}

export interface EspecialidadProps {
  isEditing: boolean;
  especialidades: Especialidad[];
  selectedEspecialidad: string;
  onEspecialidadChange: (value: string) => void;
  selectedClase: string; // Añadimos la clase seleccionada
  isLoading?: boolean;
  error?: string | null;
}
