"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { Horario } from "./Horario.interface";

export const useHorarioLogic = () => {
  const [horarios, setHorarios] = useState<Horario[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchHorarios = async () => {
      setIsLoading(true);
      setError(null);
      try {
        const response = await axios.get(`${API_BASE_URL}/Combos/horarios`);
        if (response.data.success && response.data.data) {
          setHorarios(response.data.data);
        } else {
          throw new Error(
            response.data.message || "Error al obtener los horarios"
          );
        }
      } catch (error) {
        console.error("Error al cargar los horarios:", error);
        setError(
          "No se pudieron cargar los horarios. Por favor, intente de nuevo más tarde."
        );
        Swal.fire({
          icon: "error",
          title: "Error",
          text: "No se pudieron cargar los horarios. Por favor, intente de nuevo más tarde.",
        });
      } finally {
        setIsLoading(false);
      }
    };

    fetchHorarios();
  }, []);

  return { horarios, isLoading, error };
};
