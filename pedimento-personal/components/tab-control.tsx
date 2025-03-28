"use client";

import { useEffect } from "react";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";

import { useProvinciaLogic } from "./ubicacion/provincia/Provincia.logic";
import { useCantonLogic } from "./ubicacion/canton/Canton.logic";
import { useDistritoLogic } from "./ubicacion/distrito/Distrito.logic";
import { useMotivoVacanteLogic } from "./motivo-vacante/MotivoVacante.logic";
import { useJornadaLogic } from "./jornada/Jornada.logic";
import { useHorarioLogic } from "./horario/Horario.logic";
import { useDetallesPuestoLogic } from "./tabs/detalles-puesto/DetallesPuesto.logic";
import { useObservacionesLogic } from "./tabs/observaciones/Observaciones.logic";
import { usePrestacionServiciosLogic } from "./tabs/prestacion-servicios/PrestacionServicios.logic";
import { useResolucionDeseadaLogic } from "./tabs/resolucion-deseada/ResolucionDeseada.logic";
import { useRubrosSalarialesLogic } from "./tabs/rubros-salariales/RubrosSalariales.logic";

import { DetallesPuestoTab } from "./tabs/detalles-puesto/DetallesPuesto";
import { PrestacionServiciosTab } from "./tabs/prestacion-servicios/PrestacionServicios";
import { ResolucionDeseadaTab } from "./tabs/resolucion-deseada/ResolucionDeseada";
import { RubrosSalarialesTab } from "./tabs/rubros-salariales/RubrosSalariales";
import { ObservacionesTab } from "./tabs/observaciones/Observaciones";

interface TabControlProps {
  isEditing: boolean;
  shouldReset?: boolean;
  selectedInstitucion: string;
}

// Actualicemos el estado inicial en el TabControl para incluir los nuevos campos
const initialDetallesPuesto = {
  vacantePor: "",
  jornada: "",
  horario: "",
  puestoInterino: "no",
  identificacionInterino: "",
  nombreInterino: "",
  especifique: "",
  puestoDiscapacidad: false,
  puestoAfrodescendientes: false,
};

const initialObservaciones = {
  observaciones: "",
};

const initialPrestacionServicios = {
  departamento: "",
  provincia: "",
  canton: "",
  distrito: "",
  formaDestacado: "",
  especifique1: "",
  desplazamiento: false,
  especifique2: "",
};

const initialResolucionDeseada = {
  resolverPor: "",
  especifiqueResolucion: "",
};

export function TabControl({
  isEditing,
  shouldReset = false,
  selectedInstitucion,
}: TabControlProps) {
  console.log("TabControl - selectedInstitucion:", selectedInstitucion);

  const { detallesPuesto, handleDetallesPuestoChange } = useDetallesPuestoLogic(
    initialDetallesPuesto
  );
  const { observaciones, handleObservacionesChange } =
    useObservacionesLogic(initialObservaciones);
  const {
    prestacionServicios,
    handlePrestacionServiciosChange,
    departamentos,
    isLoadingDepartamentos,
    errorDepartamentos,
  } = usePrestacionServiciosLogic(
    initialPrestacionServicios,
    selectedInstitucion
  );
  const {
    resolucionDeseada,
    handleResolucionDeseadaChange,
    tiposResolucion,
    isLoading: isLoadingTiposResolucion,
    error: errorTiposResolucion,
  } = useResolucionDeseadaLogic(initialResolucionDeseada);
  const {
    rubrosSalariales,
    handleRubrosSalarialesChange,
    agregarRubro,
    eliminarRubro,
    resetRubrosSalariales,
  } = useRubrosSalarialesLogic();

  const {
    motivosVacante,
    isLoading: isLoadingMotivosVacante,
    error: errorMotivosVacante,
  } = useMotivoVacanteLogic();
  const {
    jornadas,
    isLoading: isLoadingJornadas,
    error: errorJornadas,
  } = useJornadaLogic();
  const {
    horarios,
    isLoading: isLoadingHorarios,
    error: errorHorarios,
  } = useHorarioLogic();

  // Corregir: no pasar argumentos a useProvinciaLogic
  const {
    provincias,
    isLoading: isLoadingProvincias,
    error: errorProvincias,
  } = useProvinciaLogic();

  const {
    cantones,
    isLoading: isLoadingCantones,
    error: errorCantones,
  } = useCantonLogic(prestacionServicios.provincia);

  const {
    distritos,
    isLoading: isLoadingDistritos,
    error: errorDistritos,
  } = useDistritoLogic(
    prestacionServicios.provincia,
    prestacionServicios.canton
  );

  // También necesitamos actualizar la función de reset para incluir los nuevos campos
  useEffect(() => {
    if (shouldReset) {
      handleDetallesPuestoChange("vacantePor", "");
      handleDetallesPuestoChange("jornada", "");
      handleDetallesPuestoChange("horario", "");
      handleDetallesPuestoChange("puestoInterino", "no");
      handleDetallesPuestoChange("identificacionInterino", "");
      handleDetallesPuestoChange("nombreInterino", "");
      handleDetallesPuestoChange("especifique", "");
      handleDetallesPuestoChange("puestoDiscapacidad", false);
      handleDetallesPuestoChange("puestoAfrodescendientes", false);
      handlePrestacionServiciosChange("departamento", "");
      handlePrestacionServiciosChange("provincia", "");
      handlePrestacionServiciosChange("canton", "");
      handlePrestacionServiciosChange("distrito", "");
      handlePrestacionServiciosChange("formaDestacado", "");
      handlePrestacionServiciosChange("especifique1", "");
      handlePrestacionServiciosChange("desplazamiento", false);
      handlePrestacionServiciosChange("especifique2", "");
      handleResolucionDeseadaChange("resolverPor", "");
      handleResolucionDeseadaChange("especifiqueResolucion", "");
      resetRubrosSalariales();
      handleObservacionesChange("observaciones", "");
    }
  }, [
    shouldReset,
    handleDetallesPuestoChange,
    handleObservacionesChange,
    handlePrestacionServiciosChange,
    handleResolucionDeseadaChange,
    resetRubrosSalariales,
  ]);

  return (
    <Tabs defaultValue="detalles" className="w-full">
      <TabsList className="grid w-full grid-cols-2 lg:grid-cols-5">
        <TabsTrigger value="detalles">Detalles del puesto</TabsTrigger>
        <TabsTrigger value="prestacion">Prestación de Servicios</TabsTrigger>
        <TabsTrigger value="resolucion">
          Forma de resolución deseada
        </TabsTrigger>
        <TabsTrigger value="rubros">Rubros Salariales</TabsTrigger>
        <TabsTrigger value="observaciones">Observaciones</TabsTrigger>
      </TabsList>

      <TabsContent value="detalles">
        <DetallesPuestoTab
          isEditing={isEditing}
          detallesPuesto={detallesPuesto}
          onDetallesPuestoChange={handleDetallesPuestoChange}
          motivosVacante={motivosVacante}
          jornadas={jornadas}
          horarios={horarios}
          isLoadingMotivosVacante={isLoadingMotivosVacante}
          errorMotivosVacante={errorMotivosVacante}
          isLoadingJornadas={isLoadingJornadas}
          errorJornadas={errorJornadas}
          isLoadingHorarios={isLoadingHorarios}
          errorHorarios={errorHorarios}
        />
      </TabsContent>
      <TabsContent value="prestacion">
        <PrestacionServiciosTab
          isEditing={isEditing}
          prestacionServicios={prestacionServicios}
          onPrestacionServiciosChange={handlePrestacionServiciosChange}
          provincias={provincias}
          cantones={cantones}
          distritos={distritos}
          departamentos={departamentos}
          selectedInstitucion={selectedInstitucion}
          isLoadingDepartamentos={isLoadingDepartamentos}
          errorDepartamentos={errorDepartamentos}
        />
      </TabsContent>
      <TabsContent value="resolucion">
        <ResolucionDeseadaTab
          isEditing={isEditing}
          resolucionDeseada={resolucionDeseada}
          onResolucionDeseadaChange={handleResolucionDeseadaChange}
          tiposResolucion={tiposResolucion}
          isLoadingTiposResolucion={isLoadingTiposResolucion}
          errorTiposResolucion={errorTiposResolucion}
        />
      </TabsContent>
      <TabsContent value="rubros">
        <RubrosSalarialesTab
          isEditing={isEditing}
          rubrosSalariales={rubrosSalariales}
          onRubrosSalarialesChange={handleRubrosSalarialesChange}
          agregarRubro={agregarRubro}
          eliminarRubro={eliminarRubro}
        />
      </TabsContent>
      <TabsContent value="observaciones">
        <ObservacionesTab
          isEditing={isEditing}
          observaciones={observaciones}
          onObservacionesChange={handleObservacionesChange}
        />
      </TabsContent>
    </Tabs>
  );
}
