"use client";

import { useState, useEffect } from "react";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogDescription,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { PlusCircle, Pencil } from "lucide-react";
import { SearchableSelect } from "./searchable-select";
import {
  claseOptions as importedClaseOptions,
  ClaseOption,
} from "../data/clase-options";

const claseOptions = Array.isArray(importedClaseOptions)
  ? importedClaseOptions
  : [];

interface PedimentoModalProps {
  isEdit?: boolean;
  initialData?: {
    pedimento: string;
    numPuesto: string;
    dependencia: string;
    codPres: string;
    estrato: string;
    claseGenerica: string;
    clase: string;
    especialidad: string;
    subEspecialidad: string;
    cargo: string;
    institucion: string;
  };
}

export function PedimentoModal({
  isEdit = false,
  initialData,
}: PedimentoModalProps) {
  const [isOpen, setIsOpen] = useState(false);
  const [pedimento, setPedimento] = useState(initialData?.pedimento || "");
  const [numPuesto, setNumPuesto] = useState(initialData?.numPuesto || "");
  const [dependencia, setDependencia] = useState(
    initialData?.dependencia || ""
  );
  const [codPres, setCodPres] = useState(initialData?.codPres || "");
  const [estrato, setEstrato] = useState(initialData?.estrato || "");
  const [claseGenerica, setClaseGenerica] = useState(
    initialData?.claseGenerica || ""
  );
  const [clase, setClase] = useState(initialData?.clase || "");
  const [especialidad, setEspecialidad] = useState(
    initialData?.especialidad || ""
  );
  const [subEspecialidad, setSubEspecialidad] = useState(
    initialData?.subEspecialidad || ""
  );
  const [selectedClaseDetails, setSelectedClaseDetails] =
    useState<ClaseOption | null>(null);
  const [cargo, setCargo] = useState(initialData?.cargo || "");
  const [institucion, setInstitucion] = useState(
    initialData?.institucion || ""
  );

  useEffect(() => {
    if (initialData) {
      setPedimento(initialData.pedimento || "");
      setNumPuesto(initialData.numPuesto || "");
      setDependencia(initialData.dependencia || "");
      setCodPres(initialData.codPres || "");
      setEstrato(initialData.estrato || "");
      setClaseGenerica(initialData.claseGenerica || "");
      setClase(initialData.clase || "");
      setEspecialidad(initialData.especialidad || "");
      setSubEspecialidad(initialData.subEspecialidad || "");
      setCargo(initialData.cargo || "");
      setInstitucion(initialData.institucion || "");
    }
  }, [initialData]);

  useEffect(() => {
    if (clase && claseOptions) {
      const selectedClase = claseOptions.find(
        (option) => option.cod_clase === clase
      );
      setSelectedClaseDetails(selectedClase || null);
    } else {
      setSelectedClaseDetails(null);
    }
  }, [clase]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Aquí iría la lógica para guardar o actualizar el pedimento
    console.log({
      pedimento,
      numPuesto,
      dependencia,
      codPres,
      estrato,
      claseGenerica,
      clase,
      especialidad,
      subEspecialidad,
      selectedClaseDetails,
      cargo,
      institucion,
    });
    setIsOpen(false);
  };

  return (
    <Dialog open={isOpen} onOpenChange={setIsOpen}>
      <DialogTrigger asChild>
        {isEdit ? (
          <Button
            variant="ghost"
            size="icon"
            className="hover:bg-blue-100"
            onClick={() => setIsOpen(true)}
          >
            <Pencil className="h-4 w-4 text-blue-600" />
          </Button>
        ) : (
          <Button
            className="bg-blue-600 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:shadow-xl"
            onClick={() => setIsOpen(true)}
          >
            <PlusCircle className="mr-2 h-5 w-5" /> Nuevo Pedimento
          </Button>
        )}
      </DialogTrigger>
      <DialogContent className="sm:max-w-[800px] bg-gradient-to-br from-blue-50 to-indigo-100 rounded-xl shadow-xl">
        <DialogHeader className="border-b border-blue-200 pb-4">
          <DialogTitle className="text-2xl font-bold text-blue-800">
            {isEdit ? "Editar Pedimento" : "Nuevo Pedimento"}
          </DialogTitle>
          <DialogDescription className="text-blue-600">
            Complete la información del pedimento de personal
          </DialogDescription>
        </DialogHeader>
        <form onSubmit={handleSubmit} className="grid gap-6 py-6">
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            <div className="space-y-2">
              <Label
                htmlFor="pedimento"
                className="text-sm font-medium text-blue-800"
              >
                Pedimento
              </Label>
              <Input
                id="pedimento"
                value={pedimento}
                onChange={(e) => setPedimento(e.target.value)}
                className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
              />
            </div>
            <div className="space-y-2">
              <Label
                htmlFor="numPuesto"
                className="text-sm font-medium text-blue-800"
              >
                Num. Puesto
              </Label>
              <Input
                id="numPuesto"
                value={numPuesto}
                onChange={(e) => setNumPuesto(e.target.value)}
                className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
              />
            </div>
            <div className="space-y-2">
              <Label
                htmlFor="dependencia"
                className="text-sm font-medium text-blue-800"
              >
                Dependencia
              </Label>
              <Select value={dependencia} onValueChange={setDependencia}>
                <SelectTrigger className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md">
                  <SelectValue placeholder="Seleccione dependencia" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="rrhh">Recursos Humanos</SelectItem>
                  <SelectItem value="finanzas">Finanzas</SelectItem>
                  <SelectItem value="it">
                    Tecnología de la Información
                  </SelectItem>
                  <SelectItem value="ventas">Ventas</SelectItem>
                  <SelectItem value="marketing">Marketing</SelectItem>
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-2">
              <Label
                htmlFor="codPres"
                className="text-sm font-medium text-blue-800"
              >
                Cód. Pres.
              </Label>
              <Input
                id="codPres"
                value={codPres}
                onChange={(e) => setCodPres(e.target.value)}
                className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
              />
            </div>
            <div className="space-y-2">
              <Label
                htmlFor="estrato"
                className="text-sm font-medium text-blue-800"
              >
                Estrato
              </Label>
              <Select value={estrato} onValueChange={setEstrato}>
                <SelectTrigger className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md">
                  <SelectValue placeholder="Seleccione estrato" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="operativo">OPERATIVO</SelectItem>
                  <SelectItem value="calificado">CALIFICADO</SelectItem>
                  <SelectItem value="tecnico">TECNICO</SelectItem>
                  <SelectItem value="profesional">PROFESIONAL</SelectItem>
                  <SelectItem value="gerencial">GERENCIAL</SelectItem>
                  <SelectItem value="propiamente-docente">
                    PROPIAMENTE DOCENTE
                  </SelectItem>
                  <SelectItem value="tecnico-docente">
                    TECNICO DOCENTE
                  </SelectItem>
                  <SelectItem value="administrativo-docente">
                    ADMINISTRATIVO DOCENTE
                  </SelectItem>
                  <SelectItem value="artistico">ARTISTICO</SelectItem>
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-2">
              <Label
                htmlFor="clase-generica"
                className="text-sm font-medium text-blue-800"
              >
                Clase Genérica
              </Label>
              <Select value={claseGenerica} onValueChange={setClaseGenerica}>
                <SelectTrigger className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md">
                  <SelectValue placeholder="Seleccione clase genérica" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="trabajador-operativo-1">
                    TRABAJADOR OPERATIVO 1
                  </SelectItem>
                  <SelectItem value="trabajador-operativo-2">
                    TRABAJADOR OPERATIVO 2
                  </SelectItem>
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-2">
              <Label
                htmlFor="clase"
                className="text-sm font-medium text-blue-800"
              >
                Clase
              </Label>
              <SearchableSelect
                options={
                  claseOptions.map((option: ClaseOption) => ({
                    label: option.titulo_de_la_clase,
                    value: option.cod_clase,
                  })) || []
                }
                value={clase}
                onChange={setClase}
                placeholder="Seleccione o busque una clase"
                className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
              />
            </div>
            <div className="col-span-2 grid grid-cols-1 md:grid-cols-2 gap-6">
              <div className="space-y-2">
                <Label
                  htmlFor="especialidad"
                  className="text-sm font-medium text-blue-800"
                >
                  Especialidad
                </Label>
                <Select value={especialidad} onValueChange={setEspecialidad}>
                  <SelectTrigger className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md">
                    <SelectValue placeholder="Seleccione especialidad" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="especialidad1">
                      Especialidad 1
                    </SelectItem>
                    <SelectItem value="especialidad2">
                      Especialidad 2
                    </SelectItem>
                    <SelectItem value="especialidad3">
                      Especialidad 3
                    </SelectItem>
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-2">
                <Label
                  htmlFor="sub-especialidad"
                  className="text-sm font-medium text-blue-800"
                >
                  Sub-Especialidad
                </Label>
                <Select
                  value={subEspecialidad}
                  onValueChange={setSubEspecialidad}
                >
                  <SelectTrigger className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md">
                    <SelectValue placeholder="Seleccione sub-especialidad" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="sub-especialidad1">
                      Sub-Especialidad 1
                    </SelectItem>
                    <SelectItem value="sub-especialidad2">
                      Sub-Especialidad 2
                    </SelectItem>
                    <SelectItem value="sub-especialidad3">
                      Sub-Especialidad 3
                    </SelectItem>
                  </SelectContent>
                </Select>
              </div>
            </div>
            <div className="col-span-2 grid grid-cols-1 md:grid-cols-2 gap-6">
              <div className="space-y-2">
                <Label
                  htmlFor="cargo"
                  className="text-sm font-medium text-blue-800"
                >
                  Cargo
                </Label>
                <Select value={cargo} onValueChange={setCargo}>
                  <SelectTrigger className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md">
                    <SelectValue placeholder="Seleccione cargo" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="analista">Analista</SelectItem>
                    <SelectItem value="gerente">Gerente</SelectItem>
                    <SelectItem value="coordinador">Coordinador</SelectItem>
                    <SelectItem value="asistente">Asistente</SelectItem>
                  </SelectContent>
                </Select>
              </div>
              <div className="space-y-2">
                <Label
                  htmlFor="institucion"
                  className="text-sm font-medium text-blue-800"
                >
                  Institución
                </Label>
                <Input
                  id="institucion"
                  value={institucion}
                  onChange={(e) => setInstitucion(e.target.value)}
                  className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
                  placeholder="Ingrese la institución"
                />
              </div>
            </div>
          </div>
          {selectedClaseDetails && (
            <div className="mt-4 p-4 bg-white rounded-md shadow-md">
              <h3 className="text-lg font-semibold text-blue-800 mb-2">
                Detalles de la Clase Seleccionada
              </h3>
              <p>
                <strong>Código de Clase:</strong>{" "}
                {selectedClaseDetails.cod_clase}
              </p>
              <p>
                <strong>Título de la Clase:</strong>{" "}
                {selectedClaseDetails.titulo_de_la_clase}
              </p>
              <p>
                <strong>Nivel Salarial:</strong>{" "}
                {selectedClaseDetails.nivel_salarial}
              </p>
              <p>
                <strong>Resolución:</strong> {selectedClaseDetails.resolucion}
              </p>
              <p>
                <strong>Fecha de Resolución:</strong>{" "}
                {selectedClaseDetails.fecha_res}
              </p>
              <p>
                <strong>Gaceta:</strong> {selectedClaseDetails.gaceta}
              </p>
              <p>
                <strong>Fecha de Gaceta:</strong>{" "}
                {selectedClaseDetails.fecha_gaceta}
              </p>
            </div>
          )}
          <Button
            type="submit"
            className="ml-auto bg-blue-600 hover:bg-blue-700 text-white font-bold py-3 px-6 rounded-full shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:shadow-xl"
          >
            {isEdit ? "Guardar cambios" : "Crear pedimento"}
          </Button>
        </form>
      </DialogContent>
    </Dialog>
  );
}
