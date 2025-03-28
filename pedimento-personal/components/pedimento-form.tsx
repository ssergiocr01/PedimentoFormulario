"use client";

import { useState, useEffect } from "react";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Card, CardHeader, CardTitle, CardContent } from "@/components/ui/card";
import type { Pedimento } from "@/types/pedimento";
import { EstratoSelect } from "./estrato/Estrato";
import { useEstratoLogic } from "./estrato/Estrato.logic";
import { ClaseGenericaSelect } from "./clase-generica/ClaseGenerica";
import { useClaseGenericaLogic } from "./clase-generica/ClaseGenerica.logic";
import { ClaseSelect } from "./clase/Clase";
import { useClaseLogic } from "./clase/Clase.logic";
import { EspecialidadSelect } from "./especialidad/Especialidad";
import { useEspecialidadLogic } from "./especialidad/Especialidad.logic";
import { SubEspecialidadSelect } from "./sub-especialidad/SubEspecialidad";
import { useSubEspecialidadLogic } from "./sub-especialidad/SubEspecialidad.logic";
import { CargoSelect } from "./cargo/Cargo";
import { useCargoLogic } from "./cargo/Cargo.logic";
import { InstitucionSelect } from "./institucion/Institucion";
import { useInstitucionLogic } from "./institucion/Institucion.logic";
import { DependenciaSelect } from "./dependencia/Dependencia";
import { useDependenciaLogic } from "./dependencia/Dependencia.logic";

const initialFormData: Pedimento = {
  id: "",
  pedimento: "",
  numPuesto: "",
  dependencia: "",
  codPres: "",
  estrato: "",
  claseGenerica: "",
  clase: "",
  especialidad: "",
  subEspecialidad: "",
  cargo: "",
  institucion: "",
};

interface PedimentoFormProps {
  isEdit: boolean;
  isEditing: boolean;
  initialData?: Pedimento | null;
  onSubmit: (data: Pedimento) => void;
  shouldReset: boolean;
  onResetComplete: () => void;
  onInstitucionChange: (value: string) => void;
}

export function PedimentoForm({
  isEdit,
  isEditing,
  initialData,
  onSubmit,
  shouldReset,
  onResetComplete,
  onInstitucionChange,
}: PedimentoFormProps) {
  const [formData, setFormData] = useState<Pedimento>(initialFormData);
  const { estratos } = useEstratoLogic();
  const { clasesGenericas } = useClaseGenericaLogic(formData.estrato);
  const { clases } = useClaseLogic(formData.estrato, formData.claseGenerica);
  const {
    especialidades,
    isLoading: isLoadingEspecialidades,
    error: errorEspecialidades,
  } = useEspecialidadLogic(formData.clase);
  const { subEspecialidades } = useSubEspecialidadLogic(formData.especialidad);
  const {
    cargos,
    isLoading: isLoadingCargos,
    error: errorCargos,
  } = useCargoLogic(formData.clase, formData.institucion);
  const { instituciones } = useInstitucionLogic();
  const {
    dependencias,
    isLoading: isLoadingDependencias,
    error: errorDependencias,
  } = useDependenciaLogic(formData.institucion);

  useEffect(() => {
    if (initialData) {
      setFormData(initialData);
    }
  }, [initialData]);

  useEffect(() => {
    if (shouldReset) {
      setFormData(initialFormData);
      onResetComplete();
    }
  }, [shouldReset, onResetComplete]);

  const handleInputChange = (field: keyof Pedimento, value: string) => {
    // Verificar si el valor ha cambiado realmente para evitar actualizaciones innecesarias
    if (formData[field] === value) return;

    const newFormData = { ...formData, [field]: value };

    if (field === "estrato") {
      newFormData.claseGenerica = "";
      newFormData.clase = "";
      newFormData.especialidad = "";
      newFormData.subEspecialidad = "";
      newFormData.cargo = "";
    } else if (field === "claseGenerica") {
      newFormData.clase = "";
      newFormData.especialidad = "";
      newFormData.subEspecialidad = "";
      newFormData.cargo = "";
    } else if (field === "clase") {
      newFormData.especialidad = "";
      newFormData.subEspecialidad = "";
      newFormData.cargo = "";
    } else if (field === "especialidad") {
      newFormData.subEspecialidad = "";
    } else if (field === "institucion") {
      newFormData.dependencia = "";
      newFormData.cargo = "";
      // Solo notificar si realmente cambió el valor
      if (formData.institucion !== value) {
        console.log("Cambiando institución a:", value);
        onInstitucionChange(value);
      }
    }

    setFormData(newFormData);
  };

  return (
    <Card className="w-full bg-gradient-to-br from-blue-50 to-indigo-100 rounded-xl shadow-xl">
      <CardHeader className="border-b border-blue-200 pb-4">
        <CardTitle className="text-2xl font-bold text-blue-800">
          {isEdit ? "Editar Pedimento" : "Nuevo Pedimento"}
        </CardTitle>
      </CardHeader>
      <CardContent>
        <div className="grid gap-6 py-6">
          <div className="grid grid-cols-12 gap-6">
            <div className="col-span-6 space-y-2">
              <Label
                htmlFor="pedimento"
                className="text-sm font-medium text-blue-800"
              >
                Pedimento
              </Label>
              <Input
                id="pedimento"
                value={formData.pedimento}
                onChange={(e) => handleInputChange("pedimento", e.target.value)}
                className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
                disabled={!isEditing}
              />
            </div>
            <div className="col-span-6 space-y-2">
              <Label
                htmlFor="numPuesto"
                className="text-sm font-medium text-blue-800"
              >
                Num. Puesto
              </Label>
              <Input
                id="numPuesto"
                value={formData.numPuesto}
                onChange={(e) => handleInputChange("numPuesto", e.target.value)}
                className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
                disabled={!isEditing}
              />
            </div>
            <div className="col-span-6">
              <InstitucionSelect
                isEditing={isEditing}
                instituciones={instituciones}
                selectedInstitucion={formData.institucion}
                onInstitucionChange={(value) =>
                  handleInputChange("institucion", value)
                }
              />
            </div>
            <div className="col-span-6">
              <DependenciaSelect
                isEditing={isEditing}
                dependencias={dependencias}
                selectedDependencia={formData.dependencia}
                onDependenciaChange={(value) =>
                  handleInputChange("dependencia", value)
                }
                selectedInstitucion={formData.institucion}
                isLoading={isLoadingDependencias}
                error={errorDependencias}
              />
            </div>
            <div className="col-span-6 space-y-2">
              <Label
                htmlFor="codPres"
                className="text-sm font-medium text-blue-800"
              >
                Cód. Pres.
              </Label>
              <Input
                id="codPres"
                value={formData.codPres}
                onChange={(e) => handleInputChange("codPres", e.target.value)}
                className="w-full border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
                disabled={!isEditing}
              />
            </div>
            <div className="col-span-6">
              <EstratoSelect
                isEditing={isEditing}
                estratos={estratos}
                selectedEstrato={formData.estrato}
                onEstratoChange={(value) => handleInputChange("estrato", value)}
              />
            </div>
            <div className="col-span-6">
              <ClaseGenericaSelect
                isEditing={isEditing}
                clasesGenericas={clasesGenericas}
                selectedClaseGenerica={formData.claseGenerica}
                onClaseGenericaChange={(value) =>
                  handleInputChange("claseGenerica", value)
                }
                selectedEstrato={formData.estrato}
              />
            </div>
            <div className="col-span-6">
              <ClaseSelect
                isEditing={isEditing}
                clases={clases}
                selectedClase={formData.clase}
                onClaseChange={(value) => handleInputChange("clase", value)}
                selectedEstrato={formData.estrato}
                selectedClaseGenerica={formData.claseGenerica}
              />
            </div>
            <div className="col-span-6">
              <EspecialidadSelect
                isEditing={isEditing}
                especialidades={especialidades}
                selectedEspecialidad={formData.especialidad}
                onEspecialidadChange={(value) =>
                  handleInputChange("especialidad", value)
                }
                selectedClase={formData.clase}
                isLoading={isLoadingEspecialidades}
                error={errorEspecialidades}
              />
            </div>
            <div className="col-span-6">
              <SubEspecialidadSelect
                isEditing={isEditing}
                subEspecialidades={subEspecialidades}
                selectedSubEspecialidad={formData.subEspecialidad}
                onSubEspecialidadChange={(value) =>
                  handleInputChange("subEspecialidad", value)
                }
                selectedEspecialidad={formData.especialidad}
              />
            </div>
            <div className="col-span-6">
              <CargoSelect
                isEditing={isEditing}
                cargos={cargos}
                selectedCargo={formData.cargo}
                onCargoChange={(value) => handleInputChange("cargo", value)}
                selectedClase={formData.clase}
                selectedInstitucion={formData.institucion}
                isLoading={isLoadingCargos}
                error={errorCargos}
              />
              {isLoadingCargos && (
                <p className="text-sm text-blue-600">Cargando cargos...</p>
              )}
              {errorCargos && (
                <p className="text-sm text-red-600">{errorCargos}</p>
              )}
            </div>
          </div>
        </div>
      </CardContent>
    </Card>
  );
}
