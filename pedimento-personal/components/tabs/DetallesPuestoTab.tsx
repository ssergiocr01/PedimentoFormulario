import type React from "react"
import { Card, CardContent } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Checkbox } from "@/components/ui/checkbox"
import type { CheckedState } from "@radix-ui/react-checkbox"

import { MotivoVacanteSelect } from "../motivo-vacante/MotivoVacante"
import { JornadaSelect } from "../jornada/Jornada"
import { HorarioSelect } from "../horario/Horario"

interface DetallesPuestoTabProps {
  isEditing: boolean
  vacantePor: string
  setVacantePor: (value: string) => void
  jornada: string
  setJornada: (value: string) => void
  horario: string
  setHorario: (value: string) => void
  puestoInterino: string
  setPuestoInterino: (value: string) => void
  especifique: string
  setEspecifique: (value: string) => void
  puestoDiscapacidad: boolean
  setPuestoDiscapacidad: (value: boolean) => void
  puestoAfrodescendientes: boolean
  setPuestoAfrodescendientes: (value: boolean) => void
  motivosVacante: any[]
  jornadas: any[]
  horarios: any[]
}

export const DetallesPuestoTab: React.FC<DetallesPuestoTabProps> = ({
  isEditing,
  vacantePor,
  setVacantePor,
  jornada,
  setJornada,
  horario,
  setHorario,
  puestoInterino,
  setPuestoInterino,
  especifique,
  setEspecifique,
  puestoDiscapacidad,
  setPuestoDiscapacidad,
  puestoAfrodescendientes,
  setPuestoAfrodescendientes,
  motivosVacante,
  jornadas,
  horarios,
}) => {
  const handlePuestoDiscapacidadChange = (checked: CheckedState) => {
    setPuestoDiscapacidad(checked as boolean)
    if (checked) {
      setPuestoAfrodescendientes(false)
    }
  }

  const handlePuestoAfrodescendientesChange = (checked: CheckedState) => {
    setPuestoAfrodescendientes(checked as boolean)
    if (checked) {
      setPuestoDiscapacidad(false)
    }
  }

  return (
    <Card>
      <CardContent className="grid grid-cols-1 md:grid-cols-2 gap-6 p-8">
        <MotivoVacanteSelect
          isEditing={isEditing}
          motivosVacante={motivosVacante}
          selectedMotivoVacante={vacantePor}
          onMotivoVacanteChange={setVacantePor}
        />
        <JornadaSelect
          isEditing={isEditing}
          jornadas={jornadas}
          selectedJornada={jornada}
          onJornadaChange={setJornada}
        />
        <HorarioSelect
          isEditing={isEditing}
          horarios={horarios}
          selectedHorario={horario}
          onHorarioChange={setHorario}
        />
        <div className="space-y-2">
          <Label htmlFor="puesto-interino" className="text-sm font-medium">
            Puesto ocupado interinamente
          </Label>
          <Select disabled={!isEditing} value={puestoInterino} onValueChange={setPuestoInterino}>
            <SelectTrigger id="puesto-interino">
              <SelectValue placeholder="Seleccione una opción" />
            </SelectTrigger>
            <SelectContent>
              <SelectItem value="si">Sí</SelectItem>
              <SelectItem value="no">No</SelectItem>
            </SelectContent>
          </Select>
        </div>
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
              value={especifique}
              onChange={(e) => setEspecifique(e.target.value)}
            />
          </div>
          <div className="space-y-4">
            <div className="flex items-center justify-between space-x-2">
              <Label htmlFor="puesto-discapacidad" className="text-sm">
                Puesto reservado para personas con discapacidad
              </Label>
              <Checkbox
                id="puesto-discapacidad"
                disabled={!isEditing || puestoAfrodescendientes}
                checked={puestoDiscapacidad}
                onCheckedChange={handlePuestoDiscapacidadChange}
              />
            </div>
            <div className="flex items-center justify-between space-x-2">
              <Label htmlFor="puesto-afrodescendientes" className="text-sm">
                Puesto reservado para personas afrodescendientes
              </Label>
              <Checkbox
                id="puesto-afrodescendientes"
                disabled={!isEditing || puestoDiscapacidad}
                checked={puestoAfrodescendientes}
                onCheckedChange={handlePuestoAfrodescendientesChange}
              />
            </div>
          </div>
        </div>
      </CardContent>
    </Card>
  )
}

