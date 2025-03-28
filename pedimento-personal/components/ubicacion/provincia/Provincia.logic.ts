"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { Provincia } from "./Provincia.interface";

export const useProvinciaLogic = () => {
  const [provincias, setProvincias] = useState<Provincia[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchProvincias = async () => {
      setIsLoading(true);
      setError(null);
      try {
        const response = await axios.get(`${API_BASE_URL}/Combos/provincias`);
        if (response.data.success && response.data.data) {
          setProvincias(response.data.data);
        } else {
          throw new Error(
            response.data.message || "Error al obtener las provincias"
          );
        }
      } catch (error) {
        console.error("Error al cargar las provincias:", error);
        setError(
          "No se pudieron cargar las provincias. Por favor, intente de nuevo más tarde."
        );
        Swal.fire({
          icon: "error",
          title: "Error",
          text: "No se pudieron cargar las provincias. Por favor, intente de nuevo más tarde.",
        });
      } finally {
        setIsLoading(false);
      }
    };

    fetchProvincias();
  }, []);

  return { provincias, isLoading, error };
};
