import type React from "react"
import { Card, CardContent } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import type { ObservacionesTabProps } from "./Observaciones.interface"

export const ObservacionesTab: React.FC<ObservacionesTabProps> = ({
  isEditing,
  observaciones,
  onObservacionesChange,
}) => {
  return (
    <Card>
      <CardContent className="space-y-4 pt-4">
        <div className="space-y-2">
          <Label htmlFor="observaciones" className="text-sm font-medium">
            Observaciones adicionales
          </Label>
          <Textarea
            id="observaciones"
            placeholder="Ingrese cualquier observación adicional"
            rows={5}
            disabled={!isEditing}
            value={observaciones.observaciones}
            onChange={(e) => onObservacionesChange("observaciones", e.target.value)}
          />
        </div>
      </CardContent>
    </Card>
  )
}

