"use client";

import { useState, useEffect, useMemo } from "react";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { Label } from "@/components/ui/label";
import { RadioGroup, RadioGroupItem } from "@/components/ui/radio-group";
import { Input } from "@/components/ui/input";
import { Filter } from "lucide-react";
import { DatePicker } from "@/components/ui/date-picker";
import { useEspecialidadLogic } from "./especialidad/Especialidad.logic";
import { useSubEspecialidadLogic } from "./sub-especialidad/SubEspecialidad.logic";
import { SearchableSelect } from "./searchable-select";

// Define la estructura de datos del filtro
export interface FilterData {
  type: string;
  data: Record<string, any>;
}

export interface FilterModalProps {
  onApplyFilter?: (filterData: FilterData) => void;
  onClearSearch?: () => void;
}

export function FilterModal({
  onApplyFilter = () => {},
  onClearSearch = () => {},
}: FilterModalProps) {
  const [isOpen, setIsOpen] = useState(false);
  const [selectedFilter, setSelectedFilter] = useState<string>("all");
  const [startDate, setStartDate] = useState<Date | undefined>(undefined);
  const [endDate, setEndDate] = useState<Date | undefined>(undefined);
  const [numPuesto, setNumPuesto] = useState("");
  const [clasePuesto, setClasePuesto] = useState("");
  const [especialidad, setEspecialidad] = useState("");
  const [subEspecialidad, setSubEspecialidad] = useState("");

  const { especialidades } = useEspecialidadLogic();
  const { subEspecialidades } = useSubEspecialidadLogic(especialidad);

  // Ordenar las especialidades alfabéticamente
  const sortedEspecialidades = useMemo(() => {
    return [...especialidades].sort((a, b) =>
      a.nombreEspecialidad.localeCompare(b.nombreEspecialidad)
    );
  }, [especialidades]);

  const handleApplyFilter = () => {
    // Aseguramos que filterType siempre sea un string
    const filterType = selectedFilter || "all";

    const filterData: FilterData = {
      type: filterType,
      data: {
        codInstitucion: 8, // Valor fijo hasta implementar autenticación
      },
    };

    switch (filterType) {
      case "creationDate":
        filterData.data = { ...filterData.data, startDate, endDate };
        break;
      case "positionNumber":
        filterData.data = { ...filterData.data, numPuesto };
        break;
      case "classAndSpecialty":
        filterData.data = {
          ...filterData.data,
          clasePuesto,
          especialidad,
          subEspecialidad,
        };
        break;
      case "all":
      default:
        // No se necesitan datos adicionales
        break;
    }

    onApplyFilter(filterData);
    setIsOpen(false);
  };

  const handleClearFilter = () => {
    setSelectedFilter("all");
    setStartDate(undefined);
    setEndDate(undefined);
    setNumPuesto("");
    setClasePuesto("");
    setEspecialidad("");
    setSubEspecialidad("");
    onClearSearch();
    setIsOpen(false);
  };

  useEffect(() => {
    if (selectedFilter !== "classAndSpecialty") {
      setClasePuesto("");
      setEspecialidad("");
      setSubEspecialidad("");
    }
  }, [selectedFilter]);

  useEffect(() => {
    setSubEspecialidad("");
  }, [especialidad]);

  return (
    <Dialog open={isOpen} onOpenChange={setIsOpen}>
      <DialogTrigger asChild>
        <Button
          variant="secondary"
          className="flex items-center bg-blue-600 hover:bg-blue-700 text-white"
        >
          <Filter className="mr-2 h-4 w-4" /> Aplicar Filtro
        </Button>
      </DialogTrigger>
      <DialogContent className="sm:max-w-[700px] bg-gradient-to-br from-blue-50 to-indigo-100">
        <DialogHeader>
          <DialogTitle className="text-2xl font-bold text-blue-800">
            Aplicar Filtro
          </DialogTitle>
        </DialogHeader>
        <div className="grid grid-cols-2 gap-6 mt-4">
          <div className="space-y-4">
            <RadioGroup
              value={selectedFilter}
              onValueChange={setSelectedFilter}
            >
              <div className="flex items-center space-x-2">
                <RadioGroupItem value="creationDate" id="creationDate" />
                <Label htmlFor="creationDate" className="font-medium">
                  Fecha de Creación
                </Label>
              </div>
              <div className="flex items-center space-x-2">
                <RadioGroupItem value="positionNumber" id="positionNumber" />
                <Label htmlFor="positionNumber" className="font-medium">
                  N° de Puesto
                </Label>
              </div>
              <div className="flex items-center space-x-2">
                <RadioGroupItem
                  value="classAndSpecialty"
                  id="classAndSpecialty"
                />
                <Label htmlFor="classAndSpecialty" className="font-medium">
                  Clase y Especialidad
                </Label>
              </div>
              <div className="flex items-center space-x-2">
                <RadioGroupItem value="all" id="all" />
                <Label htmlFor="all" className="font-medium">
                  Todos
                </Label>
              </div>
            </RadioGroup>
          </div>
          <div className="space-y-4">
            {selectedFilter === "creationDate" && (
              <>
                <div className="space-y-2">
                  <Label htmlFor="startDate" className="font-medium">
                    Fecha Inicial
                  </Label>
                  <DatePicker value={startDate} onChange={setStartDate} />
                </div>
                <div className="space-y-2">
                  <Label htmlFor="endDate" className="font-medium">
                    Fecha Final
                  </Label>
                  <DatePicker value={endDate} onChange={setEndDate} />
                </div>
              </>
            )}
            {selectedFilter === "positionNumber" && (
              <div className="space-y-2">
                <Label htmlFor="numPuesto" className="font-medium">
                  Num. Puesto
                </Label>
                <Input
                  id="numPuesto"
                  value={numPuesto}
                  onChange={(e) => setNumPuesto(e.target.value)}
                  placeholder="Ingrese el número de puesto"
                  className="border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
                />
              </div>
            )}
            {selectedFilter === "classAndSpecialty" && (
              <>
                <div className="space-y-2">
                  <Label htmlFor="clasePuesto" className="font-medium">
                    Clase de Puesto
                  </Label>
                  <Input
                    id="clasePuesto"
                    value={clasePuesto}
                    onChange={(e) => setClasePuesto(e.target.value)}
                    placeholder="Ingrese la clase de puesto"
                    className="border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
                  />
                </div>
                <div className="space-y-2">
                  <Label htmlFor="especialidad" className="font-medium">
                    Especialidad
                  </Label>
                  <SearchableSelect
                    options={sortedEspecialidades.map((esp) => ({
                      label: esp.nombreEspecialidad,
                      value: esp.codEspecialidad.toString(),
                    }))}
                    value={especialidad}
                    onChange={setEspecialidad}
                    placeholder="Buscar o seleccionar especialidad"
                    className="border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
                  />
                </div>
                <div className="space-y-2">
                  <Label htmlFor="subEspecialidad" className="font-medium">
                    Sub Especialidad
                  </Label>
                  <SearchableSelect
                    options={subEspecialidades.map((subEsp) => ({
                      label: subEsp.nombreSubespecialidad,
                      value: subEsp.codSubEspecialidad.toString(),
                    }))}
                    value={subEspecialidad}
                    onChange={setSubEspecialidad}
                    placeholder="Buscar o seleccionar sub especialidad"
                    disabled={!especialidad}
                    className="border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
                  />
                </div>
              </>
            )}
            {selectedFilter === "all" && (
              <div className="flex items-center justify-center h-full">
                <p className="text-center text-blue-600 font-medium">
                  SIN FILTRO, APARECERÁN TODOS LOS PEDIMENTOS
                </p>
              </div>
            )}
          </div>
        </div>
        <div className="flex justify-between mt-6">
          <Button
            onClick={handleClearFilter}
            className="bg-gray-500 hover:bg-gray-600 text-white"
          >
            Limpiar Filtro
          </Button>
          <Button
            onClick={handleApplyFilter}
            className="bg-blue-600 hover:bg-blue-700 text-white"
          >
            Aplicar Filtro
          </Button>
        </div>
      </DialogContent>
    </Dialog>
  );
}
