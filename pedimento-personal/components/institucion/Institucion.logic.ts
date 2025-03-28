"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { Institucion } from "./Institucion.interface";

export const useInstitucionLogic = () => {
  const [instituciones, setInstituciones] = useState<Institucion[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchInstituciones = async () => {
      setIsLoading(true);
      setError(null);
      try {
        const response = await axios.get(
          `${API_BASE_URL}/Combos/instituciones`
        );
        if (response.data.success && response.data.data) {
          setInstituciones(response.data.data);
        } else {
          throw new Error(
            response.data.message || "Error al obtener las instituciones"
          );
        }
      } catch (error) {
        console.error("Error al cargar las instituciones:", error);
        setError(
          "No se pudieron cargar las instituciones. Por favor, intente de nuevo más tarde."
        );
        Swal.fire({
          icon: "error",
          title: "Error",
          text: "No se pudieron cargar las instituciones. Por favor, intente de nuevo más tarde.",
        });
      } finally {
        setIsLoading(false);
      }
    };

    fetchInstituciones();
  }, []);

  return { instituciones, isLoading, error };
};
