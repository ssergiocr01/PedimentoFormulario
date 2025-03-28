"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { DependenciaProps } from "./Dependencia.interface";
import { Loader2 } from "lucide-react";

export const DependenciaSelect: React.FC<DependenciaProps> = ({
  isEditing,
  dependencias,
  selectedDependencia,
  onDependenciaChange,
  selectedInstitucion,
  isLoading,
  error,
}) => {
  // Reemplazar la línea de ordenación con una versión segura que verifique valores undefined
  const sortedDependencias = [...dependencias]
    .filter((dependencia) => dependencia && dependencia.nombreDependencia) // Filtrar elementos undefined o sin propiedad nombreDependencia
    .sort((a, b) => a.nombreDependencia.localeCompare(b.nombreDependencia));

  return (
    <div className="space-y-2">
      <Label
        htmlFor="dependencia"
        className="text-sm font-medium text-blue-800"
      >
        Dependencia
      </Label>
      <div className="relative">
        <SearchableSelect
          options={sortedDependencias.map((dependencia) => ({
            label: dependencia.nombreDependencia,
            value: dependencia.codDependencia.toString(),
          }))}
          value={selectedDependencia}
          onChange={onDependenciaChange}
          placeholder={
            isLoading
              ? "Cargando dependencias..."
              : selectedInstitucion
              ? "Buscar o seleccionar dependencia"
              : "Seleccione primero una institución"
          }
          disabled={!isEditing || !selectedInstitucion || isLoading}
          className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
        />
        {isLoading && (
          <div className="absolute right-10 top-1/2 transform -translate-y-1/2">
            <Loader2 className="h-4 w-4 animate-spin text-blue-500" />
          </div>
        )}
      </div>
      {error && <p className="text-xs text-red-500 mt-1">{error}</p>}
    </div>
  );
};
