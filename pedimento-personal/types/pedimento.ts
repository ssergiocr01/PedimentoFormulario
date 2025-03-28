export interface PedimentoAPI {
  pedimento: string;
  codInstitucion: number;
  codDependencia: number;
  numPuesto: number;
  codPresupuesto: string;
  codEstrato: number;
  codClaseGen: number;
  codClase: string;
  codEspecialidad: number;
  codSubEspecialidad: number;
  codCargo: number;
  codMotivo: number;
  intIdentificacion: string;
  intNombre: string;
  codDepartamento: number;
  codProvincia: number;
  codCanton: number;
  codDistrito: number;
  destacado: number;
  especDestacado: string;
  traslado: boolean;
  especTraslado: string;
  codJornada: number;
  codHorario: number;
  observaciones: string;
  codTipoResolucion: number;
  detallesResolucion: string;
  consecutivo: number;
  anno: number;
  usuarioMod: string;
  usuarioReg: string;
  institucion: string;
  dependencia: string;
  nombreEstrato: string;
  nombreGenerica: string;
  tituloDeLaClase: string;
  especialidad: string;
  subespecialidad: string;
  nombreCargo: string;
  departamento: string;
  motivo: string;
  provincia: string;
  canton: string;
  distrito: string;
  jornada: string;
  horario: string;
  tipoResolucion: string;
  anulaPed: boolean;
  numPedimento: string;
  detalles: string;
  observacionesPed: string;
  fechaReg: string;
  temporal: string;
  estado: number;
  detalleEstado: string;
  jefeORH: string;
  jefeUnidad: string;
  serCivil: string;
  diasVencimiento: number;
  numEstado: number;
}

export interface ApiResponse<T> {
  success: boolean;
  message: string;
  data: T;
  errorCode?: string;
  timestamp: string;
}

export interface Pedimento {
  id: string;
  pedimento: string;
  numPuesto: string;
  dependencia: string;
  codPres: string;
  estrato: string;
  claseGenerica: string;
  clase: string;
  especialidad: string;
  subEspecialidad: string;
  cargo: string;
  institucion: string;
  estado?: number;
  fechaCreacion?: string;

  // Campos de texto descriptivos
  nombreInstitucion?: string;
  nombreDependencia?: string;
  nombreEstrato?: string;
  nombreClaseGenerica?: string;
  nombreClase?: string;
  nombreEspecialidad?: string;
  nombreSubEspecialidad?: string;
  nombreCargo?: string;
}

// Función para convertir PedimentoAPI a Pedimento
export function mapApiToPedimento(apiPedimento: PedimentoAPI): Pedimento {
  return {
    id: apiPedimento.pedimento,
    pedimento: apiPedimento.pedimento,
    numPuesto: apiPedimento.numPuesto.toString(),
    dependencia: apiPedimento.codDependencia.toString(),
    codPres: apiPedimento.codPresupuesto,
    estrato: apiPedimento.codEstrato.toString(),
    claseGenerica: apiPedimento.codClaseGen.toString(),
    clase: apiPedimento.codClase,
    especialidad: apiPedimento.codEspecialidad.toString(),
    subEspecialidad: apiPedimento.codSubEspecialidad.toString(),
    cargo: apiPedimento.codCargo.toString(),
    institucion: apiPedimento.codInstitucion.toString(),
    estado: apiPedimento.estado,
    fechaCreacion: apiPedimento.fechaReg,

    // Mapear los campos de texto descriptivos
    nombreInstitucion: apiPedimento.institucion,
    nombreDependencia: apiPedimento.dependencia,
    nombreEstrato: apiPedimento.nombreEstrato,
    nombreClaseGenerica: apiPedimento.nombreGenerica,
    nombreClase: apiPedimento.tituloDeLaClase,
    nombreEspecialidad: apiPedimento.especialidad,
    nombreSubEspecialidad: apiPedimento.subespecialidad,
    nombreCargo: apiPedimento.nombreCargo,
  };
}
