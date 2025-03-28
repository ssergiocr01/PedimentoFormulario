"use client";

import type React from "react";
import { Card, CardContent } from "@/components/ui/card";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import type { ResolucionDeseadaTabProps } from "./ResolucionDeseada.interface";
import { TipoResolucionSelect } from "../../tipo-resolucion/TipoResolucion";

export const ResolucionDeseadaTab: React.FC<ResolucionDeseadaTabProps> = ({
  isEditing,
  resolucionDeseada,
  onResolucionDeseadaChange,
  tiposResolucion,
  isLoadingTiposResolucion,
  errorTiposResolucion,
}) => {
  return (
    <Card>
      <CardContent className="space-y-4 pt-4">
        <TipoResolucionSelect
          isEditing={isEditing}
          tiposResolucion={tiposResolucion}
          selectedTipoResolucion={resolucionDeseada.resolverPor}
          onTipoResolucionChange={(value) =>
            onResolucionDeseadaChange("resolverPor", value)
          }
          isLoading={isLoadingTiposResolucion}
          error={errorTiposResolucion}
        />
        <div className="space-y-2">
          <Label
            htmlFor="especifique-resolucion"
            className="text-sm font-medium"
          >
            Especifique:
          </Label>
          <Textarea
            id="especifique-resolucion"
            placeholder="Proporcione detalles adicionales sobre la resolución"
            className="min-h-[100px] resize-none"
            disabled={!isEditing}
            value={resolucionDeseada.especifiqueResolucion}
            onChange={(e) =>
              onResolucionDeseadaChange("especifiqueResolucion", e.target.value)
            }
          />
        </div>
      </CardContent>
    </Card>
  );
};
