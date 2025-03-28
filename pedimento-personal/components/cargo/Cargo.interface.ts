export interface Cargo {
  codCargo: number;
  codInstitucion: number;
  codClase: string;
  nombreCargo: string;
}

export interface CargoProps {
  isEditing: boolean;
  cargos: Cargo[];
  selectedCargo: string;
  onCargoChange: (value: string) => void;
  selectedClase: string;
  selectedInstitucion: string;
  isLoading?: boolean;
  error?: string | null;
}
