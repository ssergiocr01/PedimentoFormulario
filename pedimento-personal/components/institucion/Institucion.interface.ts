export interface Institucion {
  codInstitucion: number;
  nombreInstitucion: string;
}

export interface InstitucionProps {
  isEditing: boolean;
  instituciones: Institucion[];
  selectedInstitucion: string;
  onInstitucionChange: (value: string) => void;
}
