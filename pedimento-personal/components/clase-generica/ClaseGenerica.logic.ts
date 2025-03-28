"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { ClaseGenerica } from "./ClaseGenerica.interface";

export const useClaseGenericaLogic = (selectedEstrato: string) => {
  const [clasesGenericas, setClasesGenericas] = useState<ClaseGenerica[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchClasesGenericas = async () => {
      if (selectedEstrato) {
        setIsLoading(true);
        setError(null);
        try {
          const response = await axios.get(
            `${API_BASE_URL}/Combos/estratos/${selectedEstrato}/clases-genericas`
          );
          if (response.data.success && response.data.data) {
            setClasesGenericas(response.data.data);
          } else {
            throw new Error(
              response.data.message || "Error al obtener las clases genéricas"
            );
          }
        } catch (error) {
          console.error("Error al cargar las clases genéricas:", error);
          setError(
            "No se pudieron cargar las clases genéricas. Por favor, intente de nuevo más tarde."
          );
          Swal.fire({
            icon: "error",
            title: "Error",
            text: "No se pudieron cargar las clases genéricas. Por favor, intente de nuevo más tarde.",
          });
        } finally {
          setIsLoading(false);
        }
      } else {
        setClasesGenericas([]);
      }
    };

    fetchClasesGenericas();
  }, [selectedEstrato]);

  return { clasesGenericas, isLoading, error };
};
