"use client";

import { useState, useEffect } from "react";
import type { PrestacionServicios } from "./PrestacionServicios.interface";
import { useDepartamentoLogic } from "../../departamento/Departamento.logic";

export const usePrestacionServiciosLogic = (
  initialState: PrestacionServicios,
  selectedInstitucion: string
) => {
  const [prestacionServicios, setPrestacionServicios] =
    useState<PrestacionServicios>(initialState);

  // Asegurarse de que selectedInstitucion sea una cadena no vacía
  const institucionId = selectedInstitucion || "";
  console.log("ID de institución en PrestacionServicios:", institucionId);

  const {
    departamentos,
    isLoading: isLoadingDepartamentos,
    error: errorDepartamentos,
  } = useDepartamentoLogic(institucionId);

  // Usar useRef para evitar actualizaciones infinitas
  const handlePrestacionServiciosChange = (
    field: keyof PrestacionServicios,
    value: string | boolean
  ) => {
    setPrestacionServicios((prev) => {
      // Si el valor es el mismo, no hacer nada para evitar re-renderizados innecesarios
      if (prev[field] === value) return prev;

      const newState = { ...prev, [field]: value };

      if (field === "provincia") {
        newState.canton = "";
        newState.distrito = "";
      } else if (field === "canton") {
        newState.distrito = "";
      }

      return newState;
    });
  };

  // Resetear el departamento cuando cambia la institución
  useEffect(() => {
    if (prestacionServicios.departamento) {
      setPrestacionServicios((prev) => ({
        ...prev,
        departamento: "",
      }));
    }
  }, [selectedInstitucion]);

  return {
    prestacionServicios,
    handlePrestacionServiciosChange,
    departamentos,
    isLoadingDepartamentos,
    errorDepartamentos,
  };
};
