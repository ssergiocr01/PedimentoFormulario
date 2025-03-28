"use client";

import { useState, useEffect, useMemo } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { Clase } from "./Clase.interface";

export const useClaseLogic = (
  selectedEstrato: string,
  selectedClaseGenerica: string
) => {
  const [clases, setClases] = useState<Clase[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchClases = async () => {
      if (selectedEstrato && selectedClaseGenerica) {
        setIsLoading(true);
        setError(null);
        try {
          const response = await axios.get(
            `${API_BASE_URL}/Combos/estratos/${selectedEstrato}/clases-genericas/${selectedClaseGenerica}/clases`
          );
          if (response.data.success && response.data.data) {
            setClases(response.data.data);
          } else {
            throw new Error(
              response.data.message || "Error al obtener las clases"
            );
          }
        } catch (error) {
          console.error("Error al cargar las clases:", error);
          setError(
            "No se pudieron cargar las clases. Por favor, intente de nuevo más tarde."
          );
          Swal.fire({
            icon: "error",
            title: "Error",
            text: "No se pudieron cargar las clases. Por favor, intente de nuevo más tarde.",
          });
        } finally {
          setIsLoading(false);
        }
      } else {
        setClases([]);
      }
    };

    fetchClases();
  }, [selectedEstrato, selectedClaseGenerica]);

  // Ordenar las clases por tituloDeLaClase usando useMemo para mejorar el rendimiento
  const sortedClases = useMemo(
    () =>
      [...clases].sort((a, b) =>
        a.tituloDeLaClase.localeCompare(b.tituloDeLaClase)
      ),
    [clases]
  );

  return { clases: sortedClases, isLoading, error };
};
