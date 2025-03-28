export interface Jornada {
  codJornada: number;
  nombreJornada: string; // Cambiado de jornadaNombre a nombreJornada
  activo?: boolean;
}

export interface JornadaProps {
  isEditing: boolean;
  jornadas: Jornada[];
  selectedJornada: string;
  onJornadaChange: (value: string) => void;
  isLoading?: boolean;
  error?: string | null;
}
