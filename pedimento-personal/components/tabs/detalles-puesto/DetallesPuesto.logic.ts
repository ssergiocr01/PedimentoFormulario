"use client";

import { useState } from "react";
import type { DetallesPuesto } from "./DetallesPuesto.interface";

export const useDetallesPuestoLogic = (initialState: DetallesPuesto) => {
  const [detallesPuesto, setDetallesPuesto] =
    useState<DetallesPuesto>(initialState);

  const handleDetallesPuestoChange = (
    field: keyof DetallesPuesto,
    value: string | boolean
  ) => {
    setDetallesPuesto((prev) => ({ ...prev, [field]: value }));

    if (field === "puestoDiscapacidad" && value === true) {
      setDetallesPuesto((prev) => ({
        ...prev,
        puestoAfrodescendientes: false,
      }));
    } else if (field === "puestoAfrodescendientes" && value === true) {
      setDetallesPuesto((prev) => ({ ...prev, puestoDiscapacidad: false }));
    }
  };

  return { detallesPuesto, handleDetallesPuestoChange };
};
