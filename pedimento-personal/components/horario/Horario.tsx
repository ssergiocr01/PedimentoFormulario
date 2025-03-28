"use client";

import type React from "react";
import { Label } from "@/components/ui/label";
import { SearchableSelect } from "@/components/searchable-select";
import type { HorarioProps } from "./Horario.interface";
import { Loader2 } from "lucide-react";

export const HorarioSelect: React.FC<HorarioProps> = ({
  isEditing,
  horarios,
  selectedHorario,
  onHorarioChange,
  isLoading,
  error,
}) => {
  return (
    <div className="space-y-2">
      <Label htmlFor="horario" className="text-sm font-medium">
        Horario
      </Label>
      <div className="relative">
        <SearchableSelect
          options={horarios.map((horario) => ({
            label: horario.nombreHorario,
            value: horario.codHorario.toString(),
          }))}
          value={selectedHorario}
          onChange={onHorarioChange}
          placeholder={
            isLoading
              ? "Cargando horarios..."
              : "Seleccione o busque un horario"
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
      {error && <p className="text-xs text-red-500 mt-1">{error}</p>}
    </div>
  );
};
