"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import type { MotivoVacante } from "./MotivoVacante.interface";

export const useMotivoVacanteLogic = () => {
  const [motivosVacante, setMotivosVacante] = useState<MotivoVacante[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchMotivosVacante = async () => {
      setIsLoading(true);
      setError(null);
      try {
        // Log para depuración
        console.log("Intentando obtener motivos de vacante");

        // Construir URL completa para depuración
        const url = `${API_BASE_URL}/Combos/motivos-vacante`;
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
          timeout: 30000,
        });

        // Log de la respuesta completa para depuración
        console.log("Respuesta completa de motivos vacante:", response);

        if (response.data) {
          console.log("Datos de motivos vacante recibidos:", response.data);

          // Verificar si la respuesta tiene la estructura esperada
          if (Array.isArray(response.data)) {
            // Si la respuesta es directamente un array
            setMotivosVacante(response.data);
            console.log(
              "Motivos vacante establecidos (array directo):",
              response.data
            );
          } else if (response.data.data && Array.isArray(response.data.data)) {
            // Si la respuesta está envuelta en un objeto con propiedad data
            setMotivosVacante(response.data.data);
            console.log(
              "Motivos vacante establecidos (objeto con data):",
              response.data.data
            );
          } else if (response.data.success === false) {
            // Si la API devuelve un error explícito
            throw new Error(
              response.data.message || "Error al obtener los motivos de vacante"
            );
          } else {
            console.error(
              "Formato de respuesta inesperado para motivos vacante:",
              response.data
            );
            throw new Error("Formato de respuesta inesperado");
          }
        } else {
          throw new Error("No se recibieron datos");
        }
      } catch (error: any) {
        console.error("Error al cargar los motivos de vacante:", error);

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
        console.log("Estado final de motivosVacante:", motivosVacante);
      }
    };

    fetchMotivosVacante();
  }, []);

  // Log adicional para verificar el valor que se está devolviendo
  console.log("Retornando motivosVacante:", motivosVacante);
  return { motivosVacante, isLoading, error };
};
