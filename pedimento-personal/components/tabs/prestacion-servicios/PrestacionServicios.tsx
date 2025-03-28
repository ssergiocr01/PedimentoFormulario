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
import type { CheckedState } from "@radix-ui/react-checkbox";

import { ProvinciaSelect } from "../../ubicacion/provincia/Provincia";
import { CantonSelect } from "../../ubicacion/canton/Canton";
import { DistritoSelect } from "../../ubicacion/distrito/Distrito";
import { DepartamentoSelect } from "../../departamento/Departamento";
import type { PrestacionServiciosTabProps } from "./PrestacionServicios.interface";

export const PrestacionServiciosTab: React.FC<PrestacionServiciosTabProps> = ({
  isEditing,
  prestacionServicios,
  onPrestacionServiciosChange,
  provincias,
  cantones,
  distritos,
  departamentos,
  selectedInstitucion,
  isLoadingDepartamentos,
  errorDepartamentos,
}) => {
  return (
    <Card>
      <CardContent className="p-6">
        <div className="grid grid-cols-12 gap-6">
          <div className="col-span-12">
            <DepartamentoSelect
              isEditing={isEditing}
              departamentos={departamentos}
              selectedDepartamento={prestacionServicios.departamento}
              onDepartamentoChange={(value) =>
                onPrestacionServiciosChange("departamento", value)
              }
              selectedInstitucion={selectedInstitucion}
              isLoading={isLoadingDepartamentos}
              error={errorDepartamentos}
            />
          </div>

          <div className="col-span-12 space-y-2">
            <Label className="text-sm font-medium text-blue-800 mb-2 block">
              Ubicación
            </Label>
            <div className="grid grid-cols-3 gap-4">
              <ProvinciaSelect
                isEditing={isEditing}
                provincias={provincias}
                selectedProvincia={prestacionServicios.provincia}
                onProvinciaChange={(value) =>
                  onPrestacionServiciosChange("provincia", value)
                }
              />
              <CantonSelect
                isEditing={isEditing}
                cantones={cantones}
                selectedCanton={prestacionServicios.canton}
                onCantonChange={(value) =>
                  onPrestacionServiciosChange("canton", value)
                }
                selectedProvincia={prestacionServicios.provincia}
              />
              <DistritoSelect
                isEditing={isEditing}
                distritos={distritos}
                selectedDistrito={prestacionServicios.distrito}
                onDistritoChange={(value) =>
                  onPrestacionServiciosChange("distrito", value)
                }
                selectedCanton={prestacionServicios.canton}
              />
            </div>
          </div>

          <div className="col-span-6 space-y-2">
            <Label
              htmlFor="forma-destacado"
              className="text-sm font-medium text-blue-800"
            >
              El Servidor Estará destacado en Forma:
            </Label>
            <Select
              disabled={!isEditing}
              value={prestacionServicios.formaDestacado}
              onValueChange={(value) =>
                onPrestacionServiciosChange("formaDestacado", value)
              }
            >
              <SelectTrigger id="forma-destacado">
                <SelectValue placeholder="Seleccione la forma" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="permanente">PERMANENTE</SelectItem>
                <SelectItem value="provisional">PROVISIONAL</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="col-span-6 space-y-2">
            <Label
              htmlFor="especifique1"
              className="text-sm font-medium text-blue-800"
            >
              Especifique
            </Label>
            <Textarea
              id="especifique1"
              placeholder="Proporcione detalles adicionales si es necesario"
              className="min-h-[100px] resize-none"
              disabled={!isEditing}
              value={prestacionServicios.especifique1}
              onChange={(e) =>
                onPrestacionServiciosChange("especifique1", e.target.value)
              }
            />
          </div>

          <div className="col-span-6 space-y-2">
            <div className="flex items-center space-x-2">
              <Checkbox
                id="desplazamiento"
                disabled={!isEditing}
                checked={prestacionServicios.desplazamiento}
                onCheckedChange={(checked: CheckedState) =>
                  onPrestacionServiciosChange(
                    "desplazamiento",
                    checked as boolean
                  )
                }
              />
              <Label htmlFor="desplazamiento" className="text-sm text-blue-800">
                El funcionario que se nombre deberá desplazarse a diferentes
                lugares del país según las necesidades del cargo
              </Label>
            </div>
          </div>

          <div className="col-span-6 space-y-2">
            <Label
              htmlFor="especifique2"
              className="text-sm font-medium text-blue-800"
            >
              Especifique
            </Label>
            <Textarea
              id="especifique2"
              placeholder="Proporcione detalles adicionales si es necesario"
              className="min-h-[100px] resize-none"
              disabled={!isEditing}
              value={prestacionServicios.especifique2}
              onChange={(e) =>
                onPrestacionServiciosChange("especifique2", e.target.value)
              }
            />
          </div>
        </div>
      </CardContent>
    </Card>
  );
};
