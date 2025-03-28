"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { TipoResolucionProps } from "./TipoResolucion.interface";
import { Loader2, AlertCircle } from "lucide-react";

export const TipoResolucionSelect: React.FC<TipoResolucionProps> = ({
  isEditing,
  tiposResolucion,
  selectedTipoResolucion,
  onTipoResolucionChange,
  isLoading,
  error,
}) => {
  // Log para depuración
  console.log("TipoResolucionSelect - props:", {
    isEditing,
    tiposResolucion,
    selectedTipoResolucion,
    isLoading,
    error,
  });

  // Asegurarse de que tiposResolucion sea un array
  const safeTiposResolucion = Array.isArray(tiposResolucion)
    ? tiposResolucion
    : [];

  return (
    <div className="space-y-2">
      <Label htmlFor="tipo-resolucion" className="text-sm font-medium">
        Resolver por
      </Label>
      <div className="relative">
        <SearchableSelect
          options={safeTiposResolucion.map((tipo) => ({
            label: tipo.nombreTipoResolucion,
            value: tipo.codTipoResolucion.toString(),
          }))}
          value={selectedTipoResolucion}
          onChange={onTipoResolucionChange}
          placeholder={
            isLoading
              ? "Cargando tipos de resolución..."
              : "Seleccione o busque un tipo de resolución"
          }
          disabled={!isEditing || isLoading}
          className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
        />
        {isLoading && (
          <div className="absolute right-10 top-1/2 transform -translate-y-1/2">
            <Loader2 className="h-4 w-4 animate-spin text-blue-500" />
          </div>
        )}
      </div>
      {error && (
        <div className="flex items-center text-xs text-red-500 mt-1">
          <AlertCircle className="h-3 w-3 mr-1" />
          <span>{error}</span>
        </div>
      )}
      {!isLoading && !error && safeTiposResolucion.length === 0 && (
        <div className="text-xs text-amber-500 mt-1">
          No se encontraron tipos de resolución disponibles.
        </div>
      )}
    </div>
  );
};
