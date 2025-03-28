"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { Dependencia } from "./Dependencia.interface";

export const useDependenciaLogic = (selectedInstitucion: string) => {
  const [dependencias, setDependencias] = useState<Dependencia[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchDependencias = async () => {
      if (!selectedInstitucion) {
        setDependencias([]);
        return;
      }

      setIsLoading(true);
      setError(null);

      try {
        // Log para depuración
        console.log(
          `Intentando obtener dependencias para institución: ${selectedInstitucion}`
        );

        // Construir URL completa para depuración
        const url = `${API_BASE_URL}/Combos/instituciones/${selectedInstitucion}/dependencias`;
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
        console.log("Respuesta completa:", response);

        if (response.data) {
          console.log("Datos recibidos:", response.data);

          // Verificar si la respuesta tiene la estructura esperada
          if (Array.isArray(response.data)) {
            // Si la respuesta es directamente un array
            setDependencias(response.data);
          } else if (response.data.data && Array.isArray(response.data.data)) {
            // Si la respuesta está envuelta en un objeto con propiedad data
            setDependencias(response.data.data);
          } else {
            console.error("Formato de respuesta inesperado:", response.data);
            throw new Error("Formato de respuesta inesperado");
          }
        } else {
          throw new Error("No se recibieron datos");
        }
      } catch (error: any) {
        console.error("Error al cargar las dependencias:", error);

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

        Swal.fire({
          icon: "error",
          title: "Error",
          text: `No se pudieron cargar las dependencias. ${error.message}`,
        });
      } finally {
        setIsLoading(false);
      }
    };

    fetchDependencias();
  }, [selectedInstitucion]);

  return { dependencias, isLoading, error };
};
