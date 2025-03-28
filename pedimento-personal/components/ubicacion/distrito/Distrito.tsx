import type React from "react"
import { Label } from "@/components/ui/label"
import { SearchableSelect } from "@/components/searchable-select"
import type { DistritoProps } from "./Distrito.interface"

export const DistritoSelect: React.FC<DistritoProps> = ({
  isEditing,
  distritos,
  selectedDistrito,
  onDistritoChange,
  selectedCanton,
}) => {
  return (
    <div className="space-y-2">
      <SearchableSelect
        options={distritos.map((distrito) => ({
          label: distrito.nombreDistrito,
          value: distrito.codDistrito.toString(),
        }))}
        value={selectedDistrito}
        onChange={onDistritoChange}
        placeholder={selectedCanton ? "Seleccione o busque un distrito" : "Seleccione primero un cantón"}
        disabled={!isEditing || !selectedCanton}
        className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
      />
      <Label htmlFor="distrito" className="text-xs text-gray-500 text-center block">
        Distrito
      </Label>
    </div>
  )
}

