"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { JornadaProps } from "./Jornada.interface";
import { Loader2, AlertCircle } from "lucide-react";

export const JornadaSelect: React.FC<JornadaProps> = ({
  isEditing,
  jornadas,
  selectedJornada,
  onJornadaChange,
  isLoading,
  error,
}) => {
  // Log para depuración
  console.log("JornadaSelect - props:", {
    isEditing,
    jornadas,
    selectedJornada,
    isLoading,
    error,
  });

  // Asegurarse de que jornadas sea un array
  const safeJornadas = Array.isArray(jornadas) ? jornadas : [];

  return (
    <div className="space-y-2">
      <Label htmlFor="jornada" className="text-sm font-medium">
        Jornada
      </Label>
      <div className="relative">
        <SearchableSelect
          options={safeJornadas.map((jornada) => ({
            label: jornada.nombreJornada, // Cambiado de jornadaNombre a nombreJornada
            value: jornada.codJornada.toString(),
          }))}
          value={selectedJornada}
          onChange={onJornadaChange}
          placeholder={
            isLoading
              ? "Cargando jornadas..."
              : "Seleccione o busque una jornada"
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
      {!isLoading && !error && safeJornadas.length === 0 && (
        <div className="text-xs text-amber-500 mt-1">
          No se encontraron jornadas disponibles.
        </div>
      )}
    </div>
  );
};
