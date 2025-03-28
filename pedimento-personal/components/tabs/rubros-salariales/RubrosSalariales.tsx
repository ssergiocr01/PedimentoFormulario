"use client"

import type React from "react"
import { Card, CardContent } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Button } from "@/components/ui/button"
import { Plus, Minus } from 'lucide-react'
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import type { RubrosSalarialesTabProps } from "./RubrosSalariales.interface"

export const RubrosSalarialesTab: React.FC<RubrosSalarialesTabProps> = ({
  isEditing,
  rubrosSalariales,
  onRubrosSalarialesChange,
  agregarRubro,
  eliminarRubro,
}) => {
  const handleRubroSeleccionado = (rubro: typeof rubrosSalariales.rubroSeleccionado) => {
    onRubrosSalarialesChange({
      ...rubrosSalariales,
      rubroSeleccionado: rubro,
    })
  }

  const handleNuevoRubroChange = (field: "nombre" | "detalles", value: string) => {
    onRubrosSalarialesChange({
      ...rubrosSalariales,
      nuevoRubro: {
        ...rubrosSalariales.nuevoRubro,
        [field]: value,
      },
    })
  }

  return (
    <Card>
      <CardContent className="p-6">
        <div className="flex flex-col md:flex-row gap-6">
          <div className="w-full md:w-1/2 border rounded-lg">
            <div className="bg-gray-100 p-4 border-b">
              <h3 className="font-medium">RUBROS SALARIALES</h3>
            </div>
            <div className="p-4">
              <Table>
                <TableHeader>
                  <TableRow>
                    <TableHead>Rubro Salarial</TableHead>
                  </TableRow>
                </TableHeader>
                <TableBody>
                  {rubrosSalariales.rubrosSalariales.length === 0 ? (
                    <TableRow>
                      <TableCell colSpan={1} className="text-center text-gray-500">
                        No hay rubros salariales agregados
                      </TableCell>
                    </TableRow>
                  ) : (
                    rubrosSalariales.rubrosSalariales.map((rubro, index) => (
                      <TableRow
                        key={`${rubro.id}-${index}`}
                        className={rubrosSalariales.rubroSeleccionado?.id === rubro.id ? "bg-blue-100" : ""}
                        onClick={() => handleRubroSeleccionado(rubro)}
                      >
                        <TableCell>{rubro.nombre}</TableCell>
                      </TableRow>
                    ))
                  )}
                </TableBody>
              </Table>
            </div>
          </div>
          <div className="w-full md:w-1/2 border rounded-lg">
            <div className="bg-gray-100 p-4 border-b flex justify-between items-center">
              <h3 className="font-medium">DETALLE RUBRO SALARIAL</h3>
              <div className="flex gap-2">
                <Button
                  variant="outline"
                  size="sm"
                  className="flex items-center gap-1"
                  onClick={agregarRubro}
                  disabled={!isEditing || !rubrosSalariales.nuevoRubro.nombre}
                >
                  <Plus className="h-4 w-4" />
                  Agregar Rubro
                </Button>
                <Button
                  variant="outline"
                  size="sm"
                  className="flex items-center gap-1"
                  onClick={eliminarRubro}
                  disabled={!isEditing || !rubrosSalariales.rubroSeleccionado}
                >
                  <Minus className="h-4 w-4" />
                  Eliminar Rubro
                </Button>
              </div>
            </div>
            <div className="p-6 space-y-4">
              <div className="space-y-2">
                <Label htmlFor="rubro-salarial">Rubro Salarial</Label>
                <Select
                  value={rubrosSalariales.nuevoRubro.nombre}
                  onValueChange={(value) => handleNuevoRubroChange("nombre", value)}
                  disabled={!isEditing}
                >
                  <SelectTrigger id="rubro-salarial">
                    <SelectValue placeholder="Seleccione el rubro salarial" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="Salario Base">Salario Base</SelectItem>
                    <SelectItem value="Prohibición">Prohibición</SelectItem>
                    <SelectItem value="Anualidades">Anualidades</SelectItem>
                    <SelectItem value="Dedicación Exclusiva">Dedicación Exclusiva</SelectItem>
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-2">
                <Label htmlFor="detalles">Detalles</Label>
                <Textarea
                  id="detalles"
                  placeholder="Ingrese los detalles del rubro salarial"
                  className="min-h-[150px]"
                  value={rubrosSalariales.nuevoRubro.detalles}
                  onChange={(e) => handleNuevoRubroChange("detalles", e.target.value)}
                  disabled={!isEditing}
                />
              </div>
            </div>
          </div>
        </div>
      </CardContent>
    </Card>
  )
}
