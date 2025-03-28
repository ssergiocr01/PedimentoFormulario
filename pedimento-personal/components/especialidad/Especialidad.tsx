"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { EspecialidadProps } from "./Especialidad.interface";
import { Loader2, AlertCircle } from "lucide-react";

export const EspecialidadSelect: React.FC<EspecialidadProps> = ({
  isEditing,
  especialidades,
  selectedEspecialidad,
  onEspecialidadChange,
  selectedClase,
  isLoading,
  error,
}) => {
  // Log para depuración
  console.log("EspecialidadSelect - props:", {
    isEditing,
    especialidades,
    selectedEspecialidad,
    selectedClase,
    isLoading,
    error,
  });

  // Ordenar las especialidades por nombreEspecialidad
  const sortedEspecialidades = [
    ...(Array.isArray(especialidades) ? especialidades : []),
  ].sort((a, b) => a.nombreEspecialidad.localeCompare(b.nombreEspecialidad));

  return (
    <div className="space-y-2">
      <Label htmlFor="especialidad" className="text-sm font-medium">
        Especialidad
      </Label>
      <div className="relative">
        <SearchableSelect
          options={sortedEspecialidades.map((especialidad) => ({
            label: especialidad.nombreEspecialidad,
            value: especialidad.codEspecialidad.toString(),
          }))}
          value={selectedEspecialidad}
          onChange={onEspecialidadChange}
          placeholder={
            isLoading
              ? "Cargando especialidades..."
              : selectedClase
              ? "Seleccione o busque una especialidad"
              : "Seleccione primero una clase"
          }
          disabled={!isEditing || isLoading || !selectedClase}
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
      {!isLoading &&
        !error &&
        sortedEspecialidades.length === 0 &&
        selectedClase && (
          <div className="text-xs text-amber-500 mt-1">
            No se encontraron especialidades para esta clase.
          </div>
        )}
      {!selectedClase && (
        <div className="text-xs text-blue-500 mt-1">
          Debe seleccionar una clase primero.
        </div>
      )}
    </div>
  );
};
