export interface DetallesPuesto {
  vacantePor: string;
  jornada: string;
  horario: string;
  puestoInterino: string;
  identificacionInterino: string;
  nombreInterino: string;
  especifique: string;
  puestoDiscapacidad: boolean;
  puestoAfrodescendientes: boolean;
}

export interface DetallesPuestoTabProps {
  isEditing: boolean;
  detallesPuesto: DetallesPuesto;
  onDetallesPuestoChange: (
    field: keyof DetallesPuesto,
    value: string | boolean
  ) => void;
  motivosVacante: any[];
  jornadas: any[];
  horarios: any[];
  isLoadingMotivosVacante?: boolean;
  errorMotivosVacante?: string | null;
  isLoadingJornadas?: boolean;
  errorJornadas?: string | null;
  isLoadingHorarios?: boolean;
  errorHorarios?: string | null;
}
