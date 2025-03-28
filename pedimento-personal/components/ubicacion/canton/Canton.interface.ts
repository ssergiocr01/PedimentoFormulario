export interface Canton {
  codCanton: number
  codProvincia: number
  nombreCanton: string
}

export interface CantonProps {
  isEditing: boolean
  cantones: Canton[]
  selectedCanton: string
  onCantonChange: (value: string) => void
  selectedProvincia: string
}

