import type { TipoResolucion } from "../../tipo-resolucion/TipoResolucion.interface";

export interface ResolucionDeseada {
  resolverPor: string;
  especifiqueResolucion: string;
}

export interface ResolucionDeseadaTabProps {
  isEditing: boolean;
  resolucionDeseada: ResolucionDeseada;
  onResolucionDeseadaChange: (
    field: keyof ResolucionDeseada,
    value: string
  ) => void;
  tiposResolucion: TipoResolucion[];
  isLoadingTiposResolucion?: boolean;
  errorTiposResolucion?: string | null;
}
