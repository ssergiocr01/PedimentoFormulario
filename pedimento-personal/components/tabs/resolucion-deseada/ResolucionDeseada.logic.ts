"use client";

import { useState } from "react";
import type { ResolucionDeseada } from "./ResolucionDeseada.interface";
import { useTipoResolucionLogic } from "../../tipo-resolucion/TipoResolucion.logic";

export const useResolucionDeseadaLogic = (initialState: ResolucionDeseada) => {
  const [resolucionDeseada, setResolucionDeseada] =
    useState<ResolucionDeseada>(initialState);
  const { tiposResolucion, isLoading, error } = useTipoResolucionLogic();

  const handleResolucionDeseadaChange = (
    field: keyof ResolucionDeseada,
    value: string
  ) => {
    setResolucionDeseada((prev) => ({ ...prev, [field]: value }));
  };

  return {
    resolucionDeseada,
    handleResolucionDeseadaChange,
    tiposResolucion,
    isLoading,
    error,
  };
};
