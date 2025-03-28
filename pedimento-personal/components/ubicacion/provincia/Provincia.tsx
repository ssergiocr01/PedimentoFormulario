import type React from "react"
import { Label } from "@/components/ui/label"
import { SearchableSelect } from "@/components/searchable-select"
import type { ProvinciaProps } from "./Provincia.interface"

export const ProvinciaSelect: React.FC<ProvinciaProps> = ({
  isEditing,
  provincias,
  selectedProvincia,
  onProvinciaChange,
}) => {
  return (
    <div className="space-y-2">
      <SearchableSelect
        options={provincias.map((provincia) => ({
          label: provincia.nombreProvincia,
          value: provincia.codProvincia.toString(),
        }))}
        value={selectedProvincia}
        onChange={onProvinciaChange}
        placeholder="Seleccione o busque una provincia"
        disabled={!isEditing}
        className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
      />
      <Label htmlFor="provincia" className="text-xs text-gray-500 text-center block">
        Provincia
      </Label>
    </div>
  )
}

