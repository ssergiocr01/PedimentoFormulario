export interface Clase {
  codClase: string
  codEstrato: number
  codClaseGen: number
  tituloDeLaClase: string
}

export interface ClaseProps {
  isEditing: boolean
  clases: Clase[]
  selectedClase: string
  onClaseChange: (value: string) => void
  selectedEstrato: string
  selectedClaseGenerica: string
}

