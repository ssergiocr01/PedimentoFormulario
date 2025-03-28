export interface Horario {
  codHorario: number;
  nombreHorario: string;
}

export interface HorarioProps {
  isEditing: boolean;
  horarios: Horario[];
  selectedHorario: string;
  onHorarioChange: (value: string) => void;
  isLoading?: boolean;
  error?: string | null;
}
