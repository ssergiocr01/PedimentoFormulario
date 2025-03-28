import type React from "react"
import { Card, CardContent } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"

interface ResolucionDeseadaTabProps {
  isEditing: boolean
  resolverPor: string
  setResolverPor: (value: string) => void
  especifiqueResolucion: string
  setEspecifiqueResolucion: (value: string) => void
}

export const ResolucionDeseadaTab: React.FC<ResolucionDeseadaTabProps> = ({
  isEditing,
  resolverPor,
  setResolverPor,
  especifiqueResolucion,
  setEspecifiqueResolucion,
}) => {
  return (
    <Card>
      <CardContent className="space-y-4 pt-4">
        <div className="space-y-2">
          <Label htmlFor="resolver-por" className="text-sm font-medium">
            Resolver por:
          </Label>
          <Select disabled={!isEditing} value={resolverPor} onValueChange={setResolverPor}>
            <SelectTrigger id="resolver-por">
              <SelectValue placeholder="Seleccione el tipo de concurso" />
            </SelectTrigger>
            <SelectContent>
              <SelectItem value="interno">CONCURSO INTERNO</SelectItem>
              <SelectItem value="externo">CONCURSO EXTERNO</SelectItem>
            </SelectContent>
          </Select>
        </div>
        <div className="space-y-2">
          <Label htmlFor="especifique-resolucion" className="text-sm font-medium">
            Especifique:
          </Label>
          <Textarea
            id="especifique-resolucion"
            placeholder="Proporcione detalles adicionales sobre la resolución"
            className="min-h-[100px] resize-none"
            disabled={!isEditing}
            value={especifiqueResolucion}
            onChange={(e) => setEspecifiqueResolucion(e.target.value)}
          />
        </div>
      </CardContent>
    </Card>
  )
}

