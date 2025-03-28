"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import type { TipoResolucion } from "./TipoResolucion.interface";

export const useTipoResolucionLogic = () => {
  const [tiposResolucion, setTiposResolucion] = useState<TipoResolucion[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchTiposResolucion = async () => {
      setIsLoading(true);
      setError(null);
      try {
        // Log para depuración
        console.log("Intentando obtener tipos de resolución");

        // Construir URL completa para depuración
        const url = `${API_BASE_URL}/Combos/tipos-resolucion`;
        console.log(`URL completa: ${url}`);

        // Hacer la solicitud con configuración explícita
        const response = await axios({
          method: "get",
          url: url,
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
          },
          // Añadir timeout para evitar esperas indefinidas
          timeout: 10000,
        });

        // Log de la respuesta completa para depuración
        console.log("Respuesta completa de tipos de resolución:", response);

        if (response.data) {
          console.log("Datos de tipos de resolución recibidos:", response.data);

          // Verificar si la respuesta tiene la estructura esperada
          if (Array.isArray(response.data)) {
            // Si la respuesta es directamente un array
            setTiposResolucion(response.data);
            console.log(
              "Tipos de resolución establecidos (array directo):",
              response.data
            );
          } else if (response.data.data && Array.isArray(response.data.data)) {
            // Si la respuesta está envuelta en un objeto con propiedad data
            setTiposResolucion(response.data.data);
            console.log(
              "Tipos de resolución establecidos (objeto con data):",
              response.data.data
            );
          } else if (response.data.success === false) {
            // Si la API devuelve un error explícito
            throw new Error(
              response.data.message ||
                "Error al obtener los tipos de resolución"
            );
          } else {
            console.error(
              "Formato de respuesta inesperado para tipos de resolución:",
              response.data
            );
            throw new Error("Formato de respuesta inesperado");
          }
        } else {
          throw new Error("No se recibieron datos");
        }
      } catch (error: any) {
        console.error("Error al cargar los tipos de resolución:", error);

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
      } finally {
        setIsLoading(false);
        // Log final para verificar el estado después de la carga
        console.log("Estado final de tiposResolucion:", tiposResolucion);
      }
    };

    fetchTiposResolucion();
  }, []);

  // Log adicional para verificar el valor que se está devolviendo
  console.log("Retornando tiposResolucion:", tiposResolucion);
  return { tiposResolucion, isLoading, error };
};
