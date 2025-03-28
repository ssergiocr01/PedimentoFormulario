import { useState } from "react"
import type { Observaciones } from "./Observaciones.interface"

export const useObservacionesLogic = (initialState: Observaciones) => {
  const [observaciones, setObservaciones] = useState<Observaciones>(initialState)

  const handleObservacionesChange = (field: keyof Observaciones, value: string) => {
    setObservaciones((prev) => ({ ...prev, [field]: value }))
  }

  return { observaciones, handleObservacionesChange }
}

