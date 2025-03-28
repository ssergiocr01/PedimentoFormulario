export interface TipoResolucion {
  codTipoResolucion: number;
  nombreTipoResolucion: string;
  activo: boolean;
}

export interface TipoResolucionProps {
  isEditing: boolean;
  tiposResolucion: TipoResolucion[];
  selectedTipoResolucion: string;
  onTipoResolucionChange: (value: string) => void;
  isLoading?: boolean;
  error?: string | null;
}
