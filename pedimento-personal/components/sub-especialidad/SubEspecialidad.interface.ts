export interface SubEspecialidad {
  codSubEspecialidad: number
  codEspecialidad: number
  nombreSubespecialidad: string
}

export interface SubEspecialidadProps {
  isEditing: boolean
  subEspecialidades: SubEspecialidad[]
  selectedSubEspecialidad: string
  onSubEspecialidadChange: (value: string) => void
  selectedEspecialidad: string
}

