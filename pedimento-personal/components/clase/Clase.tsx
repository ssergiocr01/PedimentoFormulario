"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { ClaseProps } from "./Clase.interface";

export const ClaseSelect: React.FC<ClaseProps> = ({
  isEditing,
  clases,
  selectedClase,
  onClaseChange,
  selectedEstrato,
  selectedClaseGenerica,
}) => {
  // Ordenar las clases por tituloDeLaClase
  const sortedClases = [...clases]
    .filter((clase) => clase && clase.tituloDeLaClase) // Filtrar elementos undefined o sin propiedad tituloDeLaClase
    .sort((a, b) => a.tituloDeLaClase.localeCompare(b.tituloDeLaClase));

  return (
    <div className="space-y-2 col-span-2">
      <Label htmlFor="clase" className="text-sm font-medium">
        Clase
      </Label>
      <SearchableSelect
        options={sortedClases.map((clase) => ({
          label: clase.tituloDeLaClase,
          value: clase.codClase,
        }))}
        value={selectedClase}
        onChange={onClaseChange}
        placeholder={
          selectedEstrato && selectedClaseGenerica
            ? "Seleccione o busque una clase"
            : "Seleccione primero un estrato y una clase genérica"
        }
        disabled={!isEditing || !selectedEstrato || !selectedClaseGenerica}
        className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
      />
    </div>
  );
};
