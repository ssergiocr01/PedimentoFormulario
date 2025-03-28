"use client";

import type React from "react";
import { Card, CardContent } from "@/components/ui/card";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Checkbox } from "@/components/ui/checkbox";
import { Input } from "@/components/ui/input";
import type { CheckedState } from "@radix-ui/react-checkbox";

import { MotivoVacanteSelect } from "../../motivo-vacante/MotivoVacante";
import { JornadaSelect } from "../../jornada/Jornada";
import { HorarioSelect } from "../../horario/Horario";
import type { DetallesPuestoTabProps } from "./DetallesPuesto.interface";

export const DetallesPuestoTab: React.FC<DetallesPuestoTabProps> = ({
  isEditing,
  detallesPuesto,
  onDetallesPuestoChange,
  motivosVacante,
  jornadas,
  horarios,
  isLoadingMotivosVacante,
  errorMotivosVacante,
  isLoadingJornadas,
  errorJornadas,
  isLoadingHorarios,
  errorHorarios,
}) => {
  const handlePuestoDiscapacidadChange = (checked: CheckedState) => {
    onDetallesPuestoChange("puestoDiscapacidad", checked as boolean);
  };

  const handlePuestoAfrodescendientesChange = (checked: CheckedState) => {
    onDetallesPuestoChange("puestoAfrodescendientes", checked as boolean);
  };

  // Determinar si se deben mostrar los campos de interino
  const mostrarCamposInterino = detallesPuesto.puestoInterino === "si";

  return (
    <Card>
      <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-6 p-8">
        <MotivoVacanteSelect
          isEditing={isEditing}
          motivosVacante={motivosVacante}
          selectedMotivoVacante={detallesPuesto.vacantePor}
          onMotivoVacanteChange={(value) =>
            onDetallesPuestoChange("vacantePor", value)
          }
          isLoading={isLoadingMotivosVacante}
          error={errorMotivosVacante}
        />
        <JornadaSelect
          isEditing={isEditing}
          jornadas={jornadas}
          selectedJornada={detallesPuesto.jornada}
          onJornadaChange={(value) => onDetallesPuestoChange("jornada", value)}
          isLoading={isLoadingJornadas}
          error={errorJornadas}
        />
        <HorarioSelect
          isEditing={isEditing}
          horarios={horarios}
          selectedHorario={detallesPuesto.horario}
          onHorarioChange={(value) => onDetallesPuestoChange("horario", value)}
          isLoading={isLoadingHorarios}
          error={errorHorarios}
        />
        <div className="space-y-2">
          <Label htmlFor="puesto-interino" className="text-sm font-medium">
            Puesto ocupado interinamente
          </Label>
          <Select
            disabled={!isEditing}
            value={detallesPuesto.puestoInterino}
            onValueChange={(value) =>
              onDetallesPuestoChange("puestoInterino", value)
            }
          >
            <SelectTrigger id="puesto-interino">
              <SelectValue placeholder="Seleccione una opción" />
            </SelectTrigger>
            <SelectContent>
              <SelectItem value="si">Sí</SelectItem>
              <SelectItem value="no">No</SelectItem>
            </SelectContent>
          </Select>
        </div>

        {/* Campos condicionales para interino */}
        {mostrarCamposInterino && (
          <>
            <div className="space-y-2">
              <Label
                htmlFor="identificacion-interino"
                className="text-sm font-medium"
              >
                Identificación
              </Label>
              <Input
                id="identificacion-interino"
                value={detallesPuesto.identificacionInterino}
                onChange={(e) =>
                  onDetallesPuestoChange(
                    "identificacionInterino",
                    e.target.value
                  )
                }
                placeholder="Ingrese la identificación"
                disabled={!isEditing}
                className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
              />
            </div>
            <div className="space-y-2">
              <Label htmlFor="nombre-interino" className="text-sm font-medium">
                Nombre
              </Label>
              <Input
                id="nombre-interino"
                value={detallesPuesto.nombreInterino}
                onChange={(e) =>
                  onDetallesPuestoChange("nombreInterino", e.target.value)
                }
                placeholder="Ingrese el nombre"
                disabled={!isEditing}
                className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
              />
            </div>
          </>
        )}

        <div className="grid grid-cols-1 md:grid-cols-3 gap-6 md:col-span-2 py-6">
          <div className="md:col-span-2 space-y-2">
            <Label htmlFor="especifique" className="text-sm font-medium">
              Especifique
            </Label>
            <Textarea
              id="especifique"
              placeholder="Proporcione detalles adicionales si es necesario"
              className="h-full min-h-[150px] resize-none"
              disabled={!isEditing}
              value={detallesPuesto.especifique}
              onChange={(e) =>
                onDetallesPuestoChange("especifique", e.target.value)
              }
            />
          </div>
          <div className="space-y-4">
            <div className="flex items-center justify-between space-x-2">
              <Label
                htmlFor="puesto-discapacidad"
                className="text-sm font-medium"
              >
                Puesto reservado para personas con discapacidad
              </Label>
              <Checkbox
                id="puesto-discapacidad"
                disabled={!isEditing || detallesPuesto.puestoAfrodescendientes}
                checked={detallesPuesto.puestoDiscapacidad}
                onCheckedChange={handlePuestoDiscapacidadChange}
              />
            </div>
            <div className="flex items-center justify-between space-x-2">
              <Label
                htmlFor="puesto-afrodescendientes"
                className="text-sm font-medium"
              >
                Puesto reservado para personas afrodescendientes
              </Label>
              <Checkbox
                id="puesto-afrodescendientes"
                disabled={!isEditing || detallesPuesto.puestoDiscapacidad}
                checked={detallesPuesto.puestoAfrodescendientes}
                onCheckedChange={handlePuestoAfrodescendientesChange}
              />
            </div>
          </div>
        </div>
      </CardContent>
    </Card>
  );
};
