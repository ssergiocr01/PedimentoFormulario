import type React from "react"
import { Card, CardContent } from "@/components/ui/card"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Button } from "@/components/ui/button"
import { Plus, Minus } from "lucide-react"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import Swal from "sweetalert2"

interface RubroSalarial {
  id: string
  nombre: string
  detalles: string
}

interface RubrosSalarialesTabProps {
  isEditing: boolean
  rubrosSalariales: RubroSalarial[]
  setRubrosSalariales: React.Dispatch<React.SetStateAction<RubroSalarial[]>>
  rubroSeleccionado: RubroSalarial | null
  setRubroSeleccionado: React.Dispatch<React.SetStateAction<RubroSalarial | null>>
  nuevoRubro: { nombre: string; detalles: string }
  setNuevoRubro: React.Dispatch<React.SetStateAction<{ nombre: string; detalles: string }>>
}

export const RubrosSalarialesTab: React.FC<RubrosSalarialesTabProps> = ({
  isEditing,
  rubrosSalariales,
  setRubrosSalariales,
  rubroSeleccionado,
  setRubroSeleccionado,
  nuevoRubro,
  setNuevoRubro,
}) => {
  const agregarRubro = () => {
    if (nuevoRubro.nombre && isEditing) {
      const rubroExistente = rubrosSalariales.find((rubro) => rubro.nombre === nuevoRubro.nombre)
      if (rubroExistente) {
        Swal.fire({
          icon: "error",
          title: "Rubro duplicado",
          text: "Este rubro salarial ya existe.",
          confirmButtonColor: "#3085d6",
        })
        return
      }
      const nuevoId = (rubrosSalariales.length + 1).toString()
      setRubrosSalariales([...rubrosSalariales, { ...nuevoRubro, id: nuevoId }])
      setNuevoRubro({ nombre: "", detalles: "" })
      Swal.fire({
        icon: "success",
        title: "Rubro añadido",
        text: "El rubro salarial ha sido añadido exitosamente.",
        confirmButtonColor: "#3085d6",
      })
    }
  }

  const eliminarRubro = () => {
    if (rubroSeleccionado && isEditing) {
      setRubrosSalariales(rubrosSalariales.filter((rubro) => rubro.id !== rubroSeleccionado.id))
      setRubroSeleccionado(null)
    }
  }

  return (
    <Card>
      <CardContent className="p-6">
        <div className="flex flex-col md:flex-row gap-6">
          <div className="w-full md:w-1/2 border rounded-lg">
            <div className="bg-gray-100 p-4 border-b">
              <h3 className="font-semibold">RUBROS SALARIALES</h3>
            </div>
            <div className="p-4">
              <Table>
                <TableHeader>
                  <TableRow>
                    <TableHead>Rubro Salarial</TableHead>
                  </TableRow>
                </TableHeader>
                <TableBody>
                  {rubrosSalariales.map((rubro) => (
                    <TableRow
                      key={rubro.id}
                      className={rubroSeleccionado?.id === rubro.id ? "bg-blue-100" : ""}
                      onClick={() => setRubroSeleccionado(rubro)}
                    >
                      <TableCell>{rubro.nombre}</TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </div>
          </div>
          <div className="w-full md:w-1/2 border rounded-lg">
            <div className="bg-gray-100 p-4 border-b flex justify-between items-center">
              <h3 className="font-semibold">DETALLE RUBRO SALARIAL</h3>
              <div className="flex gap-2">
                <Button
                  variant="outline"
                  size="sm"
                  className="flex items-center gap-1"
                  onClick={agregarRubro}
                  disabled={!isEditing}
                >
                  <Plus className="h-4 w-4" />
                  Agregar Rubro
                </Button>
                <Button
                  variant="outline"
                  size="sm"
                  className="flex items-center gap-1"
                  onClick={eliminarRubro}
                  disabled={!isEditing || !rubroSeleccionado}
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
                  value={nuevoRubro.nombre}
                  onValueChange={(value) => {
                    setNuevoRubro({ ...nuevoRubro, nombre: value })
                  }}
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
                  value={nuevoRubro.detalles}
                  onChange={(e) => setNuevoRubro({ ...nuevoRubro, detalles: e.target.value })}
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

