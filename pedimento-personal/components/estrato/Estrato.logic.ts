"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { Estrato } from "./Estrato.interface";

export const useEstratoLogic = () => {
  const [estratos, setEstratos] = useState<Estrato[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchEstratos = async () => {
      setIsLoading(true);
      setError(null);
      try {
        const response = await axios.get(`${API_BASE_URL}/Combos/estratos`);
        if (response.data.success && response.data.data) {
          setEstratos(response.data.data);
        } else {
          throw new Error(
            response.data.message || "Error al obtener los estratos"
          );
        }
      } catch (error) {
        console.error("Error al cargar los estratos:", error);
        setError(
          "No se pudieron cargar los estratos. Por favor, intente de nuevo más tarde."
        );
        Swal.fire({
          icon: "error",
          title: "Error",
          text: "No se pudieron cargar los estratos. Por favor, intente de nuevo más tarde.",
        });
      } finally {
        setIsLoading(false);
      }
    };

    fetchEstratos();
  }, []);

  return { estratos, isLoading, error };
};
