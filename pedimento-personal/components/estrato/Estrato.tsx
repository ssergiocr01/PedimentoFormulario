import type React from "react"
import { Label } from "@/components/ui/label"
import { SearchableSelect } from "@/components/searchable-select"
import type { EstratoProps } from "./Estrato.interface"

export const EstratoSelect: React.FC<EstratoProps> = ({ isEditing, estratos, selectedEstrato, onEstratoChange }) => {
  return (
    <div className="space-y-2">
      <Label htmlFor="estrato" className="text-sm font-medium">
        Estrato
      </Label>
      <SearchableSelect
        options={estratos.map((estrato) => ({
          label: estrato.nombreEstrato,
          value: estrato.codEstrato.toString(),
        }))}
        value={selectedEstrato}
        onChange={onEstratoChange}
        placeholder="Seleccione o busque un estrato"
        disabled={!isEditing}
        className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
      />
    </div>
  )
}

