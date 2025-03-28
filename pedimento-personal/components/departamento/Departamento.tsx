"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { DepartamentoProps } from "./Departamento.interface";
import { Loader2 } from "lucide-react";

export const DepartamentoSelect: React.FC<DepartamentoProps> = ({
  isEditing,
  departamentos,
  selectedDepartamento,
  onDepartamentoChange,
  selectedInstitucion,
  isLoading,
  error,
}) => {
  // Ordenar los departamentos alfabéticamente por nombreDepartamento
  const sortedDepartamentos = [...departamentos]
    .filter((departamento) => departamento && departamento.nombreDepartamento) // Filtrar elementos undefined o sin propiedad nombreDepartamento
    .sort((a, b) => a.nombreDepartamento.localeCompare(b.nombreDepartamento));

  return (
    <div className="space-y-2">
      <Label
        htmlFor="departamento"
        className="text-sm font-medium text-blue-800"
      >
        Dpto. u Oficina
      </Label>
      <div className="relative">
        <SearchableSelect
          options={sortedDepartamentos.map((departamento) => ({
            label: departamento.nombreDepartamento,
            value: departamento.codDepartamento.toString(),
          }))}
          value={selectedDepartamento}
          onChange={onDepartamentoChange}
          placeholder={
            isLoading
              ? "Cargando departamentos..."
              : selectedInstitucion
              ? "Buscar o seleccionar departamento"
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
