export interface Departamento {
  codDepartamento: number;
  codInstitucion: number;
  nombreDepartamento: string;
}

export interface DepartamentoProps {
  isEditing: boolean;
  departamentos: Departamento[];
  selectedDepartamento: string;
  onDepartamentoChange: (value: string) => void;
  selectedInstitucion: string;
  isLoading?: boolean;
  error?: string | null;
}
