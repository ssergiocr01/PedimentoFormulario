"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { Canton } from "./Canton.interface";

export const useCantonLogic = (selectedProvincia: string) => {
  const [cantones, setCantones] = useState<Canton[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchCantones = async () => {
      if (selectedProvincia) {
        setIsLoading(true);
        setError(null);
        try {
          const response = await axios.get(
            `${API_BASE_URL}/Combos/provincias/${selectedProvincia}/cantones`
          );
          if (response.data.success && response.data.data) {
            setCantones(response.data.data);
          } else {
            throw new Error(
              response.data.message || "Error al obtener los cantones"
            );
          }
        } catch (error) {
          console.error("Error al cargar los cantones:", error);
          setError(
            "No se pudieron cargar los cantones. Por favor, intente de nuevo más tarde."
          );
          Swal.fire({
            icon: "error",
            title: "Error",
            text: "No se pudieron cargar los cantones. Por favor, intente de nuevo más tarde.",
          });
        } finally {
          setIsLoading(false);
        }
      } else {
        setCantones([]);
      }
    };

    fetchCantones();
  }, [selectedProvincia]);

  return { cantones, isLoading, error };
};
