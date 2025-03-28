export interface Provincia {
  codProvincia: number
  nombreProvincia: string
}

export interface ProvinciaProps {
  isEditing: boolean
  provincias: Provincia[]
  selectedProvincia: string
  onProvinciaChange: (value: string) => void
}

