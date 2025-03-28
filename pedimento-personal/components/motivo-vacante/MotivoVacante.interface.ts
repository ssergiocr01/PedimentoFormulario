export interface MotivoVacante {
  codMotivo: number;
  nombreMotivo: string; // Cambiado de motivo a nombreMotivo
  activo?: boolean;
}

export interface MotivoVacanteProps {
  isEditing: boolean;
  motivosVacante: MotivoVacante[];
  selectedMotivoVacante: string;
  onMotivoVacanteChange: (value: string) => void;
  isLoading?: boolean;
  error?: string | null;
}
