"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import type { Jornada } from "./Jornada.interface";

export const useJornadaLogic = () => {
  const [jornadas, setJornadas] = useState<Jornada[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchJornadas = async () => {
      setIsLoading(true);
      setError(null);
      try {
        // Log para depuración
        console.log("Intentando obtener jornadas");

        // Construir URL completa para depuración
        const url = `${API_BASE_URL}/Combos/jornadas`;
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
        console.log("Respuesta completa de jornadas:", response);

        if (response.data) {
          console.log("Datos de jornadas recibidos:", response.data);

          // Verificar si la respuesta tiene la estructura esperada
          if (Array.isArray(response.data)) {
            // Si la respuesta es directamente un array
            setJornadas(response.data);
            console.log(
              "Jornadas establecidas (array directo):",
              response.data
            );
          } else if (response.data.data && Array.isArray(response.data.data)) {
            // Si la respuesta está envuelta en un objeto con propiedad data
            setJornadas(response.data.data);
            console.log(
              "Jornadas establecidas (objeto con data):",
              response.data.data
            );
          } else if (response.data.success === false) {
            // Si la API devuelve un error explícito
            throw new Error(
              response.data.message || "Error al obtener las jornadas"
            );
          } else {
            console.error(
              "Formato de respuesta inesperado para jornadas:",
              response.data
            );
            throw new Error("Formato de respuesta inesperado");
          }
        } else {
          throw new Error("No se recibieron datos");
        }
      } catch (error: any) {
        console.error("Error al cargar las jornadas:", error);

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
        console.log("Estado final de jornadas:", jornadas);
      }
    };

    fetchJornadas();
  }, []);

  // Log adicional para verificar el valor que se está devolviendo
  console.log("Retornando jornadas:", jornadas);
  return { jornadas, isLoading, error };
};
