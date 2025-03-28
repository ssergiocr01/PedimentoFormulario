export interface PrestacionServicios {
  departamento: string;
  provincia: string;
  canton: string;
  distrito: string;
  formaDestacado: string;
  especifique1: string;
  desplazamiento: boolean;
  especifique2: string;
}

export interface PrestacionServiciosTabProps {
  isEditing: boolean;
  prestacionServicios: PrestacionServicios;
  onPrestacionServiciosChange: (
    field: keyof PrestacionServicios,
    value: string | boolean
  ) => void;
  provincias: any[];
  cantones: any[];
  distritos: any[];
  departamentos: any[];
  selectedInstitucion: string;
  isLoadingDepartamentos?: boolean;
  errorDepartamentos?: string | null;
}
