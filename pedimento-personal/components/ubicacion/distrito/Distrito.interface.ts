export interface Distrito {
  codDistrito: number
  codCanton: number
  codProvincia: number
  nombreDistrito: string
}

export interface DistritoProps {
  isEditing: boolean
  distritos: Distrito[]
  selectedDistrito: string
  onDistritoChange: (value: string) => void
  selectedCanton: string
}

