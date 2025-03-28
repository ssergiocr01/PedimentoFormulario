"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { InstitucionProps } from "./Institucion.interface";

export const InstitucionSelect: React.FC<InstitucionProps> = ({
  isEditing,
  instituciones,
  selectedInstitucion,
  onInstitucionChange,
}) => {
  // Ordenar las instituciones alfabéticamente por nombreInstitucion
  const sortedInstituciones = [...instituciones]
    .filter((institucion) => institucion && institucion.nombreInstitucion) // Filtrar elementos undefined o sin propiedad nombreInstitucion
    .sort((a, b) => a.nombreInstitucion.localeCompare(b.nombreInstitucion));

  return (
    <div className="space-y-2">
      <Label
        htmlFor="institucion"
        className="text-sm font-medium text-blue-800"
      >
        Institución
      </Label>
      <SearchableSelect
        options={sortedInstituciones.map((institucion) => ({
          label: institucion.nombreInstitucion,
          value: institucion.codInstitucion.toString(),
        }))}
        value={selectedInstitucion}
        onChange={onInstitucionChange}
        placeholder="Buscar o seleccionar institución"
        disabled={!isEditing}
        className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
      />
    </div>
  );
};
