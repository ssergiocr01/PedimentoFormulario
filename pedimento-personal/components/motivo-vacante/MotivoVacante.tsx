"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { MotivoVacanteProps } from "./MotivoVacante.interface";
import { Loader2, AlertCircle } from "lucide-react";

export const MotivoVacanteSelect: React.FC<MotivoVacanteProps> = ({
  isEditing,
  motivosVacante,
  selectedMotivoVacante,
  onMotivoVacanteChange,
  isLoading,
  error,
}) => {
  // Log para depuración
  console.log("MotivoVacanteSelect - props:", {
    isEditing,
    motivosVacante,
    selectedMotivoVacante,
    isLoading,
    error,
  });

  // Asegurarse de que motivosVacante sea un array
  const safeMotivosVacante = Array.isArray(motivosVacante)
    ? motivosVacante
    : [];

  return (
    <div className="space-y-2">
      <Label htmlFor="motivo-vacante" className="text-sm font-medium">
        Vacante por
      </Label>
      <div className="relative">
        <SearchableSelect
          options={safeMotivosVacante.map((motivo) => ({
            label: motivo.nombreMotivo, // Cambiado de motivo a nombreMotivo
            value: motivo.codMotivo.toString(),
          }))}
          value={selectedMotivoVacante}
          onChange={onMotivoVacanteChange}
          placeholder={
            isLoading
              ? "Cargando motivos de vacante..."
              : "Seleccione o busque un motivo de vacante"
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
      {!isLoading && !error && safeMotivosVacante.length === 0 && (
        <div className="text-xs text-amber-500 mt-1">
          No se encontraron motivos de vacante disponibles.
        </div>
      )}
    </div>
  );
};
