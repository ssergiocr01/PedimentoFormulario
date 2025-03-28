"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { SubEspecialidadProps } from "./SubEspecialidad.interface";

export const SubEspecialidadSelect: React.FC<SubEspecialidadProps> = ({
  isEditing,
  subEspecialidades,
  selectedSubEspecialidad,
  onSubEspecialidadChange,
  selectedEspecialidad,
}) => {
  // Ordenar las subespecialidades por nombreSubespecialidad
  const sortedSubEspecialidades = [...subEspecialidades]
    .filter(
      (subEspecialidad) =>
        subEspecialidad && subEspecialidad.nombreSubespecialidad
    ) // Filtrar elementos undefined o sin propiedad nombreSubespecialidad
    .sort((a, b) =>
      a.nombreSubespecialidad.localeCompare(b.nombreSubespecialidad)
    );

  return (
    <div className="space-y-2">
      <Label htmlFor="sub-especialidad" className="text-sm font-medium">
        Sub-Especialidad
      </Label>
      <SearchableSelect
        options={sortedSubEspecialidades.map((subEspecialidad) => ({
          label: subEspecialidad.nombreSubespecialidad,
          value: subEspecialidad.codSubEspecialidad.toString(),
        }))}
        value={selectedSubEspecialidad}
        onChange={onSubEspecialidadChange}
        placeholder={
          selectedEspecialidad
            ? "Seleccione o busque una subespecialidad"
            : "Seleccione primero una especialidad"
        }
        disabled={!isEditing || !selectedEspecialidad}
        className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
      />
    </div>
  );
};
