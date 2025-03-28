export interface RubroSalarial {
  id: string
  nombre: string
  detalles: string
}

export interface RubrosSalariales {
  rubrosSalariales: RubroSalarial[]
  rubroSeleccionado: RubroSalarial | null
  nuevoRubro: { nombre: string; detalles: string }
}

export interface RubrosSalarialesTabProps {
  isEditing: boolean
  rubrosSalariales: RubrosSalariales
  onRubrosSalarialesChange: (rubrosSalariales: RubrosSalariales) => void
  agregarRubro: () => void
  eliminarRubro: () => void
}

