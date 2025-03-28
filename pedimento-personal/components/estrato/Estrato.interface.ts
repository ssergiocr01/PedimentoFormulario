export interface Estrato {
  codEstrato: number
  nombreEstrato: string
}

export interface EstratoProps {
  isEditing: boolean
  estratos: Estrato[]
  selectedEstrato: string
  onEstratoChange: (value: string) => void
}

