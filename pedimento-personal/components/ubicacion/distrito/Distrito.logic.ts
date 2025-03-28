"use client";

import { useState, useEffect } from "react";
import axios from "axios";
import { API_BASE_URL } from "@/config/api";
import Swal from "sweetalert2";
import type { Distrito } from "./Distrito.interface";

export const useDistritoLogic = (
  selectedProvincia: string,
  selectedCanton: string
) => {
  const [distritos, setDistritos] = useState<Distrito[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchDistritos = async () => {
      if (selectedProvincia && selectedCanton) {
        setIsLoading(true);
        setError(null);
        try {
          const response = await axios.get(
            `${API_BASE_URL}/Combos/provincias/${selectedProvincia}/cantones/${selectedCanton}/distritos`
          );
          if (response.data.success && response.data.data) {
            setDistritos(response.data.data);
          } else {
            throw new Error(
              response.data.message || "Error al obtener los distritos"
            );
          }
        } catch (error) {
          console.error("Error al cargar los distritos:", error);
          setError(
            "No se pudieron cargar los distritos. Por favor, intente de nuevo más tarde."
          );
          Swal.fire({
            icon: "error",
            title: "Error",
            text: "No se pudieron cargar los distritos. Por favor, intente de nuevo más tarde.",
          });
        } finally {
          setIsLoading(false);
        }
      } else {
        setDistritos([]);
      }
    };

    fetchDistritos();
  }, [selectedProvincia, selectedCanton]);

  return { distritos, isLoading, error };
};
