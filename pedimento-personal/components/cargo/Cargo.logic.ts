// Modificar la función useCargoLogic para mejorar el manejo de errores y depuración

"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import type { Cargo } from "./Cargo.interface";

export const useCargoLogic = (
  selectedClase: string,
  selectedInstitucion: string
) => {
  const [cargos, setCargos] = useState<Cargo[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCargos = async () => {
      if (!selectedInstitucion || !selectedClase) {
        setCargos([]);
        return;
      }

      setIsLoading(true);
      setError(null);

      try {
        // Log para depuración
        console.log(
          `Intentando obtener cargos para institución: ${selectedInstitucion} y clase: ${selectedClase}`
        );

        // Construir URL completa para depuración
        const url = `${API_BASE_URL}/Combos/instituciones/${selectedInstitucion}/clases/${selectedClase}/cargos`;
        console.log(`URL completa: ${url}`);

        // Hacer la solicitud con configuración explícita
        const response = await axios({
          method: "get",
          url: url,
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
          },
        });

        // Log de la respuesta completa para depuración
        console.log("Respuesta completa de cargos:", response);

        if (response.data) {
          console.log("Datos de cargos recibidos:", response.data);

          // Verificar si la respuesta tiene la estructura esperada
          if (Array.isArray(response.data)) {
            // Si la respuesta es directamente un array
            setCargos(response.data);
          } else if (response.data.data && Array.isArray(response.data.data)) {
            // Si la respuesta está envuelta en un objeto con propiedad data
            setCargos(response.data.data);
          } else if (response.data.success === false) {
            // Si la API devuelve un error explícito
            throw new Error(
              response.data.message || "Error al obtener los cargos"
            );
          } else {
            console.error(
              "Formato de respuesta inesperado para cargos:",
              response.data
            );
            throw new Error("Formato de respuesta inesperado");
          }
        } else {
          throw new Error("No se recibieron datos");
        }
      } catch (error: any) {
        console.error("Error al cargar los cargos:", error);

        // Mostrar información detallada del error
        if (error.response) {
          // El servidor respondió con un código de estado fuera del rango 2xx
          console.error("Datos de error:", error.response.data);
          console.error("Estado de error:", error.response.status);
          console.error("Encabezados de error:", error.response.headers);
          setError(
            `Error del servidor: ${error.response.status} - ${
              error.response.data?.message || "Sin mensaje"
            }`
          );
        } else if (error.request) {
          // La solicitud se realizó pero no se recibió respuesta
          console.error("Solicitud sin respuesta:", error.request);
          setError("No se recibió respuesta del servidor");
        } else {
          // Algo ocurrió al configurar la solicitud que desencadenó un error
          console.error("Error de configuración:", error.message);
          setError(`Error: ${error.message}`);
        }

        // No mostrar alerta para evitar múltiples alertas
        // Solo establecer el estado de error para mostrarlo en la UI
      } finally {
        setIsLoading(false);
      }
    };

    fetchCargos();
  }, [selectedInstitucion, selectedClase]);

  return { cargos, isLoading, error };
};
