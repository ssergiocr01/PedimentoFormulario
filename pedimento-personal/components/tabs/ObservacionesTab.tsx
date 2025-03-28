import type React from "react"
import { Card, CardContent } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"

interface ObservacionesTabProps {
  isEditing: boolean
  observaciones: string
  setObservaciones: (value: string) => void
}

export const ObservacionesTab: React.FC<ObservacionesTabProps> = ({ isEditing, observaciones, setObservaciones }) => {
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
            value={observaciones}
            onChange={(e) => setObservaciones(e.target.value)}
          />
        </div>
      </CardContent>
    </Card>
  )
}

