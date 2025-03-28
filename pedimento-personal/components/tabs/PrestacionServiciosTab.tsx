import type React from "react"
import { Card, CardContent } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Checkbox } from "@/components/ui/checkbox"
import type { CheckedState } from "@radix-ui/react-checkbox"

import { ProvinciaSelect } from "../ubicacion/provincia/Provincia"
import { CantonSelect } from "../ubicacion/canton/Canton"
import { DistritoSelect } from "../ubicacion/distrito/Distrito"

interface PrestacionServiciosTabProps {
  isEditing: boolean
  departamento: string
  setDepartamento: (value: string) => void
  selectedProvincia: string
  setSelectedProvincia: (value: string) => void
  selectedCanton: string
  setSelectedCanton: (value: string) => void
  selectedDistrito: string
  setSelectedDistrito: (value: string) => void
  formaDestacado: string
  setFormaDestacado: (value: string) => void
  especifique1: string
  setEspecifique1: (value: string) => void
  desplazamiento: boolean
  setDesplazamiento: (value: boolean) => void
  especifique2: string
  setEspecifique2: (value: string) => void
  provincias: any[]
  cantones: any[]
  distritos: any[]
}

export const PrestacionServiciosTab: React.FC<PrestacionServiciosTabProps> = ({
  isEditing,
  departamento,
  setDepartamento,
  selectedProvincia,
  setSelectedProvincia,
  selectedCanton,
  setSelectedCanton,
  selectedDistrito,
  setSelectedDistrito,
  formaDestacado,
  setFormaDestacado,
  especifique1,
  setEspecifique1,
  desplazamiento,
  setDesplazamiento,
  especifique2,
  setEspecifique2,
  provincias,
  cantones,
  distritos,
}) => {
  const handleProvinciaChange = (value: string) => {
    setSelectedProvincia(value)
    setSelectedCanton("")
    setSelectedDistrito("")
  }

  const handleCantonChange = (value: string) => {
    setSelectedCanton(value)
    setSelectedDistrito("")
  }

  return (
    <Card>
      <CardContent className="grid grid-cols-1 gap-6 p-8">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div className="space-y-2">
            <Label htmlFor="departamento" className="text-sm font-medium">
              Dpto. u Oficina
            </Label>
            <Select disabled={!isEditing} value={departamento} onValueChange={setDepartamento}>
              <SelectTrigger id="departamento">
                <SelectValue placeholder="Seleccione el departamento u oficina" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="rrhh">Recursos Humanos</SelectItem>
                <SelectItem value="finanzas">Finanzas</SelectItem>
                <SelectItem value="it">Tecnología de la Información</SelectItem>
                <SelectItem value="ventas">Ventas</SelectItem>
                <SelectItem value="marketing">Marketing</SelectItem>
              </SelectContent>
            </Select>
          </div>
        </div>
        <div className="space-y-2">
          <Label className="text-sm font-medium mb-2 block">Ubicación</Label>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
            <ProvinciaSelect
              isEditing={isEditing}
              provincias={provincias}
              selectedProvincia={selectedProvincia}
              onProvinciaChange={handleProvinciaChange}
            />
            <CantonSelect
              isEditing={isEditing}
              cantones={cantones}
              selectedCanton={selectedCanton}
              onCantonChange={handleCantonChange}
              selectedProvincia={selectedProvincia}
            />
            <DistritoSelect
              isEditing={isEditing}
              distritos={distritos}
              selectedDistrito={selectedDistrito}
              onDistritoChange={setSelectedDistrito}
              selectedCanton={selectedCanton}
            />
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div className="space-y-2 py-6">
            <Label htmlFor="forma-destacado" className="text-sm font-medium">
              El Servidor Estará destacado en Forma:
            </Label>
            <Select disabled={!isEditing} value={formaDestacado} onValueChange={setFormaDestacado}>
              <SelectTrigger id="forma-destacado">
                <SelectValue placeholder="Seleccione la forma" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="permanente">PERMANENTE</SelectItem>
                <SelectItem value="provisional">PROVISIONAL</SelectItem>
              </SelectContent>
            </Select>
          </div>
          <div className="space-y-2 py-6">
            <Label htmlFor="especifique1" className="text-sm font-medium">
              Especifique
            </Label>
            <Textarea
              id="especifique1"
              placeholder="Proporcione detalles adicionales si es necesario"
              className="h-full min-h-[150px] resize-none"
              disabled={!isEditing}
              value={especifique1}
              onChange={(e) => setEspecifique1(e.target.value)}
            />
          </div>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div className="space-y-2 py-6">
            <div className="flex items-center space-x-2">
              <Checkbox
                id="desplazamiento"
                disabled={!isEditing}
                checked={desplazamiento}
                onCheckedChange={(checked: CheckedState) => setDesplazamiento(checked as boolean)}
              />
              <Label htmlFor="desplazamiento" className="text-sm">
                El funcionario que se nombre deberá desplazarse a diferentes lugares del país según las necesidades del
                cargo
              </Label>
            </div>
          </div>
          <div className="space-y-2 py-6">
            <Label htmlFor="especifique2" className="text-sm font-medium">
              Especifique
            </Label>
            <Textarea
              id="especifique2"
              placeholder="Proporcione detalles adicionales si es necesario"
              className="h-full min-h-[150px] resize-none"
              disabled={!isEditing}
              value={especifique2}
              onChange={(e) => setEspecifique2(e.target.value)}
            />
          </div>
        </div>
      </CardContent>
    </Card>
  )
}

