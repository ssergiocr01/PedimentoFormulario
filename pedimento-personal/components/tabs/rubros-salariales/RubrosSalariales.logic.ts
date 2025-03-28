"use client"

import { useState, useCallback } from "react"
import type { RubrosSalariales } from "./RubrosSalariales.interface"
import Swal from "sweetalert2"

const initialRubrosSalariales: RubrosSalariales = {
  rubrosSalariales: [], // Inicializamos con un array vacío
  rubroSeleccionado: null,
  nuevoRubro: { nombre: "", detalles: "" },
}

export const useRubrosSalarialesLogic = () => {
  const [rubrosSalariales, setRubrosSalariales] = useState<RubrosSalariales>(initialRubrosSalariales)

  const handleRubrosSalarialesChange = useCallback((update: Partial<RubrosSalariales>) => {
    setRubrosSalariales((prev) => ({ ...prev, ...update }))
  }, [])

  const agregarRubro = useCallback(() => {
    if (rubrosSalariales.nuevoRubro.nombre) {
      const rubroExistente = rubrosSalariales.rubrosSalariales.find(
        (rubro) => rubro.nombre.toLowerCase() === rubrosSalariales.nuevoRubro.nombre.toLowerCase(),
      )
      if (rubroExistente) {
        Swal.fire({
          icon: "error",
          title: "Rubro duplicado",
          text: "Este rubro salarial ya existe.",
          confirmButtonColor: "#3085d6",
        })
        return
      }
      const nuevoId = (rubrosSalariales.rubrosSalariales.length + 1).toString()
      const nuevosRubros = [...rubrosSalariales.rubrosSalariales, { ...rubrosSalariales.nuevoRubro, id: nuevoId }]
      setRubrosSalariales((prev) => ({
        ...prev,
        rubrosSalariales: nuevosRubros,
        nuevoRubro: { nombre: "", detalles: "" },
      }))
      Swal.fire({
        icon: "success",
        title: "Rubro añadido",
        text: "El rubro salarial ha sido añadido exitosamente.",
        confirmButtonColor: "#3085d6",
      })
    }
  }, [rubrosSalariales])

  const eliminarRubro = useCallback(() => {
    if (rubrosSalariales.rubroSeleccionado) {
      Swal.fire({
        title: "¿Está seguro?",
        text: "No podrá revertir esta acción!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sí, eliminar!",
        cancelButtonText: "Cancelar",
      }).then((result) => {
        if (result.isConfirmed) {
          setRubrosSalariales((prev) => ({
            ...prev,
            rubrosSalariales: prev.rubrosSalariales.filter((rubro) => rubro.id !== prev.rubroSeleccionado!.id),
            rubroSeleccionado: null,
          }))
          Swal.fire("Eliminado!", "El rubro salarial ha sido eliminado.", "success")
        }
      })
    }
  }, [rubrosSalariales.rubroSeleccionado])

  const resetRubrosSalariales = useCallback(() => {
    setRubrosSalariales(initialRubrosSalariales)
  }, [])

  return {
    rubrosSalariales,
    handleRubrosSalarialesChange,
    agregarRubro,
    eliminarRubro,
    resetRubrosSalariales,
  }
}

