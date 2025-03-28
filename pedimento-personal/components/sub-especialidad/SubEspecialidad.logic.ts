"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { SubEspecialidad } from "./SubEspecialidad.interface";

export const useSubEspecialidadLogic = (selectedEspecialidad: string) => {
  const [subEspecialidades, setSubEspecialidades] = useState<SubEspecialidad[]>(
    []
  );
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchSubEspecialidades = async () => {
      if (selectedEspecialidad) {
        setIsLoading(true);
        setError(null);
        try {
          const response = await axios.get(
            `${API_BASE_URL}/Combos/especialidades/${selectedEspecialidad}/subespecialidades`
          );
          if (response.data.success && response.data.data) {
            setSubEspecialidades(response.data.data);
          } else {
            throw new Error(
              response.data.message || "Error al obtener las subespecialidades"
            );
          }
        } catch (error) {
          console.error("Error al cargar las subespecialidades:", error);
          setError(
            "No se pudieron cargar las subespecialidades. Por favor, intente de nuevo más tarde."
          );
          Swal.fire({
            icon: "error",
            title: "Error",
            text: "No se pudieron cargar las subespecialidades. Por favor, intente de nuevo más tarde.",
          });
        } finally {
          setIsLoading(false);
        }
      } else {
        setSubEspecialidades([]);
      }
    };

    fetchSubEspecialidades();
  }, [selectedEspecialidad]);

  return { subEspecialidades, isLoading, error };
};
