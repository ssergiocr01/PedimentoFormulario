"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { CargoProps } from "./Cargo.interface";
import { Loader2 } from "lucide-react";

export const CargoSelect: React.FC<CargoProps> = ({
  isEditing,
  cargos,
  selectedCargo,
  onCargoChange,
  selectedClase,
  selectedInstitucion,
  isLoading,
  error,
}) => {
  // Ordenar los cargos por nombreCargo
  const sortedCargos = [...cargos]
    .filter((cargo) => cargo && cargo.nombreCargo) // Filtrar elementos undefined o sin propiedad nombreCargo
    .sort((a, b) => a.nombreCargo.localeCompare(b.nombreCargo));

  return (
    <div className="space-y-2">
      <Label htmlFor="cargo" className="text-sm font-medium">
        Cargo
      </Label>
      <div className="relative">
        <SearchableSelect
          options={sortedCargos.map((cargo) => ({
            label: cargo.nombreCargo,
            value: cargo.codCargo.toString(),
          }))}
          value={selectedCargo}
          onChange={onCargoChange}
          placeholder={
            isLoading
              ? "Cargando cargos..."
              : selectedClase && selectedInstitucion
              ? "Buscar o seleccionar un cargo"
              : "Seleccione primero una clase y una institución"
          }
          disabled={
            !isEditing || !selectedClase || !selectedInstitucion || isLoading
          }
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
