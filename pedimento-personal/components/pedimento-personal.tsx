"use client";

import type React from "react";

import { useState, useMemo, useCallback, useEffect } from "react";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardHeader,
  CardTitle,
  CardDescription,
  CardContent,
  CardFooter,
} from "@/components/ui/card";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import {
  PlusCircle,
  Save,
  Printer,
  ArrowLeft,
  RefreshCw,
  FileText,
  ChevronLeft,
  ChevronRight,
  Loader2,
  ArrowUpDown,
  ArrowUp,
  ArrowDown,
} from "lucide-react";
import { TabControl } from "./tab-control";
import { FilterModal, type FilterData } from "./filter-modal";
import { PedimentoForm } from "./pedimento-form";
import Swal from "sweetalert2";
import type { Pedimento } from "@/types/pedimento";
import { Input } from "@/components/ui/input";
import { getPedimentos } from "@/services/pedimento.service";
import { getEstadoDescripcion } from "@/utils/estado-pedimento";
import { format, parseISO } from "date-fns";
import { es } from "date-fns/locale";

// Tipo para la ordenación
type SortDirection = "asc" | "desc" | null;
type SortableColumn =
  | "pedimento"
  | "clase"
  | "especialidad"
  | "subEspecialidad"
  | "numPuesto"
  | "dependencia"
  | "institucion"
  | "estado"
  | "fechaCreacion";

export default function PedimentoPersonal() {
  const [pedimentos, setPedimentos] = useState<Pedimento[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [editingPedimento, setEditingPedimento] = useState<Pedimento | null>(
    null
  );
  const [isEditing, setIsEditing] = useState(false);
  const [currentPage, setCurrentPage] = useState(1);
  const [shouldResetForm, setShouldResetForm] = useState(false);
  const [selectedInstitucion, setSelectedInstitucion] = useState("");
  const [searchTerm, setSearchTerm] = useState("");
  const [itemsPerPage, setItemsPerPage] = useState<number>(5); // Agregado aquí dentro del componente

  // Estados para la ordenación
  const [sortColumn, setSortColumn] = useState<SortableColumn | null>(null);
  const [sortDirection, setSortDirection] = useState<SortDirection>(null);

  // Función para formatear fechas
  const formatDate = (dateString: string | undefined): string => {
    if (!dateString) return "N/A";
    try {
      return format(parseISO(dateString), "dd/MM/yyyy", { locale: es });
    } catch (error) {
      console.error("Error al formatear la fecha:", error);
      return dateString;
    }
  };

  // Función para aplicar estilos directamente
  const getEstadoStyle = (codigo: number | undefined): React.CSSProperties => {
    if (codigo === undefined || codigo === null) {
      return { backgroundColor: "#f3f4f6", color: "#1f2937" }; // Gris por defecto
    }

    // Mapeo de estados específicos a colores con valores hexadecimales
    switch (codigo) {
      case 1: // EN CONFECCION
      case 17: // MODIFICANDOSE POR LA ORH
        return { backgroundColor: "#dbeafe", color: "#1e40af" }; // Azul

      case 2: // FIRMADO POR JEFE DE ORH
      case 3: // FIRMADO POR JEFE DE UNIDAD
      case 4: // ENVIADO A SERVICIO CIVIL
      case 7: // RECIBIDO POR SERVICIO CIVIL
        return { backgroundColor: "#e0e7ff", color: "#3730a3" }; // Índigo

      case 5: // FIRMADO POR SERVICIO CIVIL
        return { backgroundColor: "#dcfce7", color: "#166534" }; // Verde

      case 6: // DEVUELTA A LA ORH
        return { backgroundColor: "#ffedd5", color: "#9a3412" }; // Naranja

      case 8: // PARA NOMINA
      case 9: // CON PROPUESTA PARA CONCURSO INTERNO
      case 10: // PARA CONCURSO EXTERNO
        return { backgroundColor: "#fef9c3", color: "#854d0e" }; // Amarillo

      case 21: // REACTIVADO
      case 25: // RESERVANDO/LIBERANDO DISCAPACIDAD
        return { backgroundColor: "#bfdbfe", color: "#1e40af" }; // Azul claro

      default:
        return { backgroundColor: "#f3f4f6", color: "#1f2937" }; // Gris
    }
  };

  // Función para buscar en todos los campos
  const searchInAllFields = (pedimento: Pedimento, term: string): boolean => {
    const searchTermLower = term.toLowerCase();

    // Buscar en todos los campos relevantes
    return (
      (pedimento.pedimento || "").toLowerCase().includes(searchTermLower) ||
      (pedimento.nombreClase || pedimento.clase || "")
        .toLowerCase()
        .includes(searchTermLower) ||
      (pedimento.nombreEspecialidad || pedimento.especialidad || "")
        .toLowerCase()
        .includes(searchTermLower) ||
      (pedimento.nombreSubEspecialidad || pedimento.subEspecialidad || "")
        .toLowerCase()
        .includes(searchTermLower) ||
      (pedimento.numPuesto || "").toLowerCase().includes(searchTermLower) ||
      (pedimento.nombreDependencia || pedimento.dependencia || "")
        .toLowerCase()
        .includes(searchTermLower) ||
      (pedimento.nombreInstitucion || pedimento.institucion || "")
        .toLowerCase()
        .includes(searchTermLower) ||
      (pedimento.estado !== undefined
        ? getEstadoDescripcion(pedimento.estado).toLowerCase()
        : ""
      ).includes(searchTermLower) ||
      (pedimento.fechaCreacion
        ? formatDate(pedimento.fechaCreacion).toLowerCase()
        : ""
      ).includes(searchTermLower)
    );
  };

  // Cargar los pedimentos desde la API
  useEffect(() => {
    const loadPedimentos = async () => {
      setIsLoading(true);
      setError(null);

      // Agregar un pequeño retraso para asegurar que todos los componentes estén montados
      await new Promise((resolve) => setTimeout(resolve, 500));

      try {
        console.log("Iniciando carga de pedimentos...");
        const data = await getPedimentos();
        console.log(`Pedimentos cargados: ${data.length}`);
        setPedimentos(data);
      } catch (err: any) {
        console.error("Error capturado en el componente:", err);
        setError(err.message || "Error al cargar los pedimentos");

        // Mostrar un mensaje más amigable
        Swal.fire({
          icon: "error",
          title: "Error de conexión",
          text:
            err.message ||
            "No se pudo conectar con el servidor. Por favor, verifique su conexión e inténtelo nuevamente.",
          confirmButtonText: "Reintentar",
          showCancelButton: true,
          cancelButtonText: "Cerrar",
        }).then((result) => {
          if (result.isConfirmed) {
            // Si el usuario hace clic en reintentar, recargamos la página
            window.location.reload();
          }
        });
      } finally {
        setIsLoading(false);
      }
    };

    loadPedimentos();
  }, []);

  // Función para manejar el clic en los encabezados de columna para ordenar
  const handleSort = (column: SortableColumn) => {
    if (sortColumn === column) {
      // Si ya estamos ordenando por esta columna, cambiamos la dirección
      if (sortDirection === "asc") {
        setSortDirection("desc");
      } else if (sortDirection === "desc") {
        // Si ya está en descendente, quitamos la ordenación
        setSortColumn(null);
        setSortDirection(null);
      }
    } else {
      // Si es una columna nueva, ordenamos ascendente
      setSortColumn(column);
      setSortDirection("asc");
    }
  };

  // Función para obtener el valor de un campo para ordenar
  const getSortValue = (
    pedimento: Pedimento,
    column: SortableColumn
  ): string | number | undefined => {
    switch (column) {
      case "pedimento":
        return pedimento.pedimento;
      case "clase":
        return pedimento.nombreClase || pedimento.clase;
      case "especialidad":
        return pedimento.nombreEspecialidad || pedimento.especialidad;
      case "subEspecialidad":
        return pedimento.nombreSubEspecialidad || pedimento.subEspecialidad;
      case "numPuesto":
        return pedimento.numPuesto;
      case "dependencia":
        return pedimento.nombreDependencia || pedimento.dependencia;
      case "institucion":
        return pedimento.nombreInstitucion || pedimento.institucion;
      case "estado":
        return pedimento.estado !== undefined
          ? getEstadoDescripcion(pedimento.estado)
          : "";
      case "fechaCreacion":
        return pedimento.fechaCreacion;
      default:
        return "";
    }
  };

  const filteredPedimentos = useMemo(() => {
    // Primero filtramos por término de búsqueda
    const filtered = searchTerm
      ? pedimentos.filter((pedimento) =>
          searchInAllFields(pedimento, searchTerm)
        )
      : pedimentos;

    // Luego ordenamos si es necesario
    if (sortColumn && sortDirection) {
      return [...filtered].sort((a, b) => {
        const aValue = getSortValue(a, sortColumn);
        const bValue = getSortValue(b, sortColumn);

        // Si alguno de los valores es undefined, lo tratamos como cadena vacía
        const aStr = aValue !== undefined ? String(aValue) : "";
        const bStr = bValue !== undefined ? String(bValue) : "";

        // Ordenar
        if (sortDirection === "asc") {
          return aStr.localeCompare(bStr);
        } else {
          return bStr.localeCompare(aStr);
        }
      });
    }

    return filtered;
  }, [pedimentos, searchTerm, sortColumn, sortDirection]);

  // Actualizar el cálculo de currentPedimentos para usar itemsPerPage:
  const currentPedimentos = useMemo(() => {
    const start = (currentPage - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    return filteredPedimentos.slice(start, end);
  }, [filteredPedimentos, currentPage, itemsPerPage]);

  // Actualizar el cálculo de totalPages para usar itemsPerPage en lugar de ITEMS_PER_PAGE:
  const totalPages = Math.ceil(filteredPedimentos.length / itemsPerPage);

  // Resetear la página actual cuando cambia el filtro o la ordenación
  useEffect(() => {
    setCurrentPage(1);
  }, [searchTerm, sortColumn, sortDirection, itemsPerPage]);

  const handleDelete = (id: string | undefined) => {
    if (!id) return; // Si id es undefined o vacío, no hacer nada

    Swal.fire({
      title: "¿Está seguro?",
      text: "No podrá revertir esta acción!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Sí, eliminar!",
      cancelButtonText: "Cancelar",
    }).then((result) => {
      if (result.isConfirmed) {
        setPedimentos(pedimentos.filter((pedimento) => pedimento.id !== id));
        Swal.fire("Eliminado!", "El pedimento ha sido eliminado.", "success");
      }
    });
  };

  const handleSubmit = (data: Pedimento) => {
    if (editingPedimento) {
      setPedimentos(
        pedimentos.map((p) =>
          p.id === editingPedimento.id ? { ...p, ...data } : p
        )
      );
      setEditingPedimento(null);
    } else {
      setPedimentos([...pedimentos, { ...data, id: Date.now().toString() }]);
    }
    setIsEditing(false);

    // Solo actualizar si realmente cambió
    if (selectedInstitucion !== data.institucion) {
      console.log("Actualizando institución seleccionada a:", data.institucion);
      setSelectedInstitucion(data.institucion);
    }

    Swal.fire(
      "Guardado!",
      "El pedimento ha sido guardado exitosamente.",
      "success"
    );
  };

  const handleNewClick = useCallback(() => {
    setEditingPedimento(null);
    setIsEditing(true);
    setShouldResetForm(true);
  }, []);

  const handleApplyFilter = (filterData: FilterData) => {
    console.log("Filtro aplicado:", filterData);
    // Aquí implementaríamos la lógica de filtrado real
    // Por ahora solo mostramos un mensaje de éxito
    Swal.fire({
      title: "Filtro aplicado",
      text: `Se ha aplicado el filtro: ${filterData.type}`,
      icon: "success",
      confirmButtonColor: "#3085d6",
    });
  };

  const handleClearSearch = () => {
    console.log("Filtro limpiado");
    setSearchTerm("");
    // Aquí implementaríamos la lógica para mostrar todos los pedimentos
    // Por ahora solo mostramos un mensaje de éxito
    Swal.fire({
      title: "Filtro limpiado",
      text: "Se han eliminado todos los filtros",
      icon: "info",
      confirmButtonColor: "#3085d6",
    });
  };

  // Componente para el encabezado de columna ordenable
  const SortableHeader = ({
    column,
    label,
  }: {
    column: SortableColumn;
    label: string;
  }) => {
    // Determinar qué icono mostrar
    let SortIcon = ArrowUpDown;
    if (sortColumn === column) {
      SortIcon = sortDirection === "asc" ? ArrowUp : ArrowDown;
    }

    return (
      <TableHead
        className="text-white font-medium cursor-pointer hover:bg-blue-700 transition-colors"
        onClick={() => handleSort(column)}
      >
        <div className="flex items-center justify-between">
          <span>{label}</span>
          <SortIcon className="h-4 w-4 ml-1" />
        </div>
      </TableHead>
    );
  };

  return (
    <Card className="w-full max-w-6xl mx-auto bg-gradient-to-br from-blue-100 via-blue-200 to-blue-300">
      <CardHeader className="text-center">
        <CardTitle className="text-3xl font-bold text-blue-800">
          Pedimento de Personal
        </CardTitle>
        <CardDescription>
          Complete la información del puesto y los detalles de la solicitud
        </CardDescription>
      </CardHeader>
      <CardContent className="p-6">
        <div className="flex flex-wrap gap-2 mb-4">
          <Button
            className="bg-blue-600 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded-full shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:shadow-xl"
            onClick={handleNewClick}
          >
            <PlusCircle className="mr-2 h-5 w-5" /> Nuevo
          </Button>
          <FilterModal
            onApplyFilter={handleApplyFilter}
            onClearSearch={handleClearSearch}
          />
          <Button variant="outline" className="flex items-center">
            <Printer className="mr-2 h-4 w-4" /> Imprimir
          </Button>
          <div className="flex-grow">
            <Input
              placeholder="Buscar en todos los campos..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              className="w-full max-w-md ml-auto border-blue-200 focus:border-blue-400 focus:ring focus:ring-blue-200 focus:ring-opacity-50 rounded-md"
            />
          </div>
        </div>

        <div className="rounded-lg overflow-hidden border border-gray-200 shadow-lg mb-6">
          {isLoading ? (
            <div className="flex justify-center items-center p-8">
              <Loader2 className="h-8 w-8 animate-spin text-blue-600" />
              <span className="ml-2 text-blue-600">Cargando pedimentos...</span>
            </div>
          ) : error ? (
            <div className="p-8 text-center">
              <div className="bg-red-50 border border-red-200 rounded-lg p-6 max-w-md mx-auto">
                <div className="flex justify-center mb-4">
                  <div className="rounded-full bg-red-100 p-3">
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      className="h-6 w-6 text-red-600"
                      fill="none"
                      viewBox="0 0 24 24"
                      stroke="currentColor"
                    >
                      <path
                        strokeLinecap="round"
                        strokeLinejoin="round"
                        strokeWidth={2}
                        d="M12 8v4m0 4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                      />
                    </svg>
                  </div>
                </div>
                <h3 className="text-lg font-medium text-red-800 mb-2">
                  Error de conexión
                </h3>
                <p className="text-red-700 mb-4">{error}</p>
                <div className="flex justify-center space-x-3">
                  <Button
                    onClick={() => window.location.reload()}
                    className="bg-red-600 hover:bg-red-700 text-white"
                  >
                    Reintentar
                  </Button>
                  <Button
                    variant="outline"
                    onClick={() => setError(null)}
                    className="border-red-300 text-red-700 hover:bg-red-50"
                  >
                    Continuar sin datos
                  </Button>
                </div>
              </div>
            </div>
          ) : (
            <Table>
              <TableHeader>
                <TableRow className="bg-blue-600">
                  <SortableHeader column="pedimento" label="Pedimento" />
                  <SortableHeader column="clase" label="Clase de Puesto" />
                  <SortableHeader column="especialidad" label="Especialidad" />
                  <SortableHeader
                    column="subEspecialidad"
                    label="Sub Especialidad"
                  />
                  <SortableHeader column="numPuesto" label="No. Puesto" />
                  <SortableHeader column="dependencia" label="Dependencia" />
                  <SortableHeader column="institucion" label="Institución" />
                  <SortableHeader column="estado" label="Estado" />
                  <SortableHeader
                    column="fechaCreacion"
                    label="Fecha Creación"
                  />
                  <TableHead className="text-white font-medium">
                    Acciones
                  </TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {currentPedimentos.length === 0 ? (
                  <TableRow>
                    <TableCell colSpan={10} className="text-center py-8">
                      No se encontraron pedimentos
                    </TableCell>
                  </TableRow>
                ) : (
                  currentPedimentos.map((row, index) => (
                    <TableRow
                      key={row.id || `row-${index}`}
                      className={index % 2 === 0 ? "bg-white" : "bg-gray-50"}
                    >
                      <TableCell className="font-medium">
                        {row.pedimento || "N/A"}
                      </TableCell>
                      <TableCell className="font-medium">
                        {row.nombreClase || row.clase || "N/A"}
                      </TableCell>
                      <TableCell className="font-medium">
                        {row.nombreEspecialidad || row.especialidad || "N/A"}
                      </TableCell>
                      <TableCell className="font-medium">
                        {row.nombreSubEspecialidad ||
                          row.subEspecialidad ||
                          "N/A"}
                      </TableCell>
                      <TableCell className="font-medium">
                        {row.numPuesto || "N/A"}
                      </TableCell>
                      <TableCell className="font-medium">
                        {row.nombreDependencia || row.dependencia || "N/A"}
                      </TableCell>
                      <TableCell className="font-medium">
                        {row.nombreInstitucion || row.institucion || "N/A"}
                      </TableCell>
                      <TableCell className="font-medium">
                        {row.estado !== undefined && (
                          <span
                            className="px-2 py-1 rounded-full text-xs font-semibold"
                            style={getEstadoStyle(row.estado)}
                            data-estado={row.estado}
                          >
                            {getEstadoDescripcion(row.estado)}
                          </span>
                        )}
                        {row.estado === undefined && (
                          <span className="px-2 py-1 rounded-full text-xs font-semibold bg-gray-100 text-gray-800">
                            DESCONOCIDO
                          </span>
                        )}
                      </TableCell>
                      <TableCell className="font-medium">
                        {formatDate(row.fechaCreacion)}
                      </TableCell>
                      <TableCell>
                        <div className="flex space-x-2">
                          <Button
                            variant="ghost"
                            size="icon"
                            className="hover:bg-blue-100"
                            onClick={() => {
                              setEditingPedimento(row);
                              setIsEditing(true);
                            }}
                          >
                            <PlusCircle className="h-4 w-4 text-blue-600" />
                          </Button>
                        </div>
                      </TableCell>
                    </TableRow>
                  ))
                )}
              </TableBody>
            </Table>
          )}
        </div>

        {/* Selector de registros por página */}
        {!isLoading && !error && filteredPedimentos.length > 0 && (
          <div className="flex items-center justify-end mb-4">
            <span className="text-sm text-gray-700 mr-2">
              Registros por página:
            </span>
            <select
              className="border border-gray-300 rounded-md px-2 py-1 text-sm focus:outline-none focus:ring-2 focus:ring-blue-500"
              value={itemsPerPage}
              onChange={(e) => {
                setItemsPerPage(Number(e.target.value));
                setCurrentPage(1); // Resetear a la primera página cuando cambia la cantidad
              }}
            >
              <option value={5}>5</option>
              <option value={10}>10</option>
              <option value={20}>20</option>
            </select>
          </div>
        )}

        {/* Paginación */}
        {!isLoading && !error && filteredPedimentos.length > 0 && (
          <div className="flex items-center justify-between">
            <Button
              onClick={() => setCurrentPage((page) => Math.max(page - 1, 1))}
              disabled={currentPage === 1}
              variant="outline"
            >
              <ChevronLeft className="h-4 w-4 mr-2" />
              Anterior
            </Button>
            <span>
              Página {currentPage} de {totalPages}
            </span>
            <Button
              onClick={() =>
                setCurrentPage((page) => Math.min(page + 1, totalPages))
              }
              disabled={currentPage === totalPages}
              variant="outline"
            >
              Siguiente
              <ChevronRight className="h-4 w-4 ml-2" />
            </Button>
          </div>
        )}

        <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mb-6 mt-6">
          <Card className="bg-green-100 border-green-300">
            <CardHeader>
              <CardTitle className="text-green-800 flex items-center font-medium">
                <ArrowLeft className="mr-2 h-5 w-5" />
                Pedimentos Devueltos
              </CardTitle>
            </CardHeader>
            <CardContent>
              <p className="text-2xl font-bold text-green-600">3</p>
              <p className="text-sm text-green-700">
                Pedimentos requieren atención
              </p>
            </CardContent>
          </Card>

          <Card className="bg-yellow-100 border-yellow-300">
            <CardHeader>
              <CardTitle className="text-yellow-800 flex items-center font-medium">
                <RefreshCw className="mr-2 h-5 w-5" />
                Solicitudes de Modificaciones Aprobadas
              </CardTitle>
            </CardHeader>
            <CardContent>
              <p className="text-2xl font-bold text-yellow-600">2</p>
              <p className="text-sm text-yellow-700">
                Modificaciones listas para aplicar
              </p>
            </CardContent>
          </Card>

          <Card className="bg-white border-gray-300">
            <CardHeader>
              <CardTitle className="text-gray-800 flex items-center font-medium">
                <FileText className="mr-2 h-5 w-5" />
                Pedimentos Nuevos
              </CardTitle>
            </CardHeader>
            <CardContent>
              <p className="text-2xl font-bold text-gray-600">5</p>
              <p className="text-sm text-gray-700">
                Nuevos pedimentos por procesar
              </p>
            </CardContent>
          </Card>
        </div>

        <PedimentoForm
          isEdit={!!editingPedimento}
          isEditing={isEditing}
          initialData={editingPedimento}
          onSubmit={handleSubmit}
          shouldReset={shouldResetForm}
          onResetComplete={() => setShouldResetForm(false)}
          onInstitucionChange={setSelectedInstitucion}
        />

        <TabControl
          isEditing={isEditing}
          shouldReset={shouldResetForm}
          selectedInstitucion={selectedInstitucion}
        />
      </CardContent>
      <CardFooter className="flex justify-end">
        <Button className="flex items-center">
          <Save className="mr-2 h-4 w-4" /> Guardar Cambios
        </Button>
      </CardFooter>
    </Card>
  );
}
