export interface Dependencia {
  codDependencia: number;
  codInstitucion: number;
  nombreDependencia: string;
}

export interface DependenciaProps {
  isEditing: boolean;
  dependencias: Dependencia[];
  selectedDependencia: string;
  onDependenciaChange: (value: string) => void;
  selectedInstitucion: string;
  isLoading?: boolean;
  error?: string | null;
}
