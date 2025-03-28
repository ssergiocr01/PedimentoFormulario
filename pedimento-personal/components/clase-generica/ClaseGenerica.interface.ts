export interface ClaseGenerica {
  codClaseGen: number
  codEstrato: number
  nombreGenerica: string
}

export interface ClaseGenericaProps {
  isEditing: boolean
  clasesGenericas: ClaseGenerica[]
  selectedClaseGenerica: string
  onClaseGenericaChange: (value: string) => void
  selectedEstrato: string
}

