import type React from "react"
import { Label } from "@/components/ui/label"
import { SearchableSelect } from "@/components/searchable-select"
import type { CantonProps } from "./Canton.interface"

export const CantonSelect: React.FC<CantonProps> = ({
  isEditing,
  cantones,
  selectedCanton,
  onCantonChange,
  selectedProvincia,
}) => {
  return (
    <div className="space-y-2">
      <SearchableSelect
        options={cantones.map((canton) => ({
          label: canton.nombreCanton,
          value: canton.codCanton.toString(),
        }))}
        value={selectedCanton}
        onChange={onCantonChange}
        placeholder={selectedProvincia ? "Seleccione o busque un cantón" : "Seleccione primero una provincia"}
        disabled={!isEditing || !selectedProvincia}
        className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
      />
      <Label htmlFor="canton" className="text-xs text-gray-500 text-center block">
        Cantón
      </Label>
    </div>
  )
}

