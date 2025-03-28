export interface Observaciones {
  observaciones: string
}

export interface ObservacionesTabProps {
  isEditing: boolean
  observaciones: Observaciones
  onObservacionesChange: (field: keyof Observaciones, value: string) => void
}

