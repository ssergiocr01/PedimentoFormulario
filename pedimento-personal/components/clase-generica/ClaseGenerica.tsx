import type React from "react"
import { Label } from "@/components/ui/label"
import { SearchableSelect } from "@/components/searchable-select"
import type { ClaseGenericaProps } from "./ClaseGenerica.interface"

export const ClaseGenericaSelect: React.FC<ClaseGenericaProps> = ({
  isEditing,
  clasesGenericas,
  selectedClaseGenerica,
  onClaseGenericaChange,
  selectedEstrato,
}) => {
  return (
    <div className="space-y-2">
      <Label htmlFor="clase-generica" className="text-sm font-medium">
        Clase Genérica
      </Label>
      <SearchableSelect
        options={clasesGenericas.map((claseGenerica) => ({
          label: claseGenerica.nombreGenerica,
          value: claseGenerica.codClaseGen.toString(),
        }))}
        value={selectedClaseGenerica}
        onChange={onClaseGenericaChange}
        placeholder={selectedEstrato ? "Seleccione o busque una clase genérica" : "Seleccione primero un estrato"}
        disabled={!isEditing || !selectedEstrato}
        className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
      />
    </div>
  )
}

