"use client";

import type React from "react";

import { useState, useRef, useEffect } from "react";
import { CalendarIcon } from "lucide-react";
import {
  format,
  subDays,
  startOfWeek,
  startOfMonth,
  startOfYear,
} from "date-fns";
import { es } from "date-fns/locale";
import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";

interface EnhancedDatePickerProps {
  value?: Date;
  onChange: (date: Date | undefined) => void;
  placeholder?: string;
  className?: string;
  showPresets?: boolean;
}

export function EnhancedDatePicker({
  value,
  onChange,
  placeholder = "Seleccionar fecha",
  className,
  showPresets = true,
}: EnhancedDatePickerProps) {
  const [open, setOpen] = useState(false);
  const [inputValue, setInputValue] = useState<string>(
    value ? format(value, "dd/MM/yyyy") : ""
  );
  const inputRef = useRef<HTMLInputElement>(null);

  // Actualizar el valor del input cuando cambia el valor de la fecha
  useEffect(() => {
    if (value) {
      setInputValue(format(value, "dd/MM/yyyy"));
    } else {
      setInputValue("");
    }
  }, [value]);

  // Manejar cambios en el input
  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setInputValue(e.target.value);

    // Intentar parsear la fecha del input
    const parts = e.target.value.split("/");
    if (parts.length === 3) {
      const day = Number.parseInt(parts[0], 10);
      const month = Number.parseInt(parts[1], 10) - 1; // Los meses en JS son 0-indexed
      const year = Number.parseInt(parts[2], 10);

      if (!isNaN(day) && !isNaN(month) && !isNaN(year)) {
        const date = new Date(year, month, day);
        if (
          date.getDate() === day &&
          date.getMonth() === month &&
          date.getFullYear() === year
        ) {
          onChange(date);
          return;
        }
      }
    }

    // Si no se pudo parsear, y el input está vacío, establecer la fecha como undefined
    if (e.target.value === "") {
      onChange(undefined);
    }
  };

  // Opciones predefinidas de fechas
  const presets = [
    { label: "Hoy", value: new Date() },
    { label: "Ayer", value: subDays(new Date(), 1) },
    {
      label: "Esta semana",
      value: startOfWeek(new Date(), { weekStartsOn: 1 }),
    },
    {
      label: "Semana pasada",
      value: startOfWeek(subDays(new Date(), 7), { weekStartsOn: 1 }),
    },
    { label: "Este mes", value: startOfMonth(new Date()) },
    {
      label: "Mes pasado",
      value: startOfMonth(subDays(startOfMonth(new Date()), 1)),
    },
    { label: "Este año", value: startOfYear(new Date()) },
    { label: "Limpiar", value: undefined },
  ];

  return (
    <div className={cn("relative", className)}>
      <Popover open={open} onOpenChange={setOpen}>
        <PopoverTrigger asChild>
          <Button
            variant="outline"
            role="combobox"
            aria-expanded={open}
            className="w-full justify-start text-left font-normal"
            onClick={() => setOpen(true)}
          >
            <CalendarIcon className="mr-2 h-4 w-4" />
            {value ? (
              format(value, "dd/MM/yyyy")
            ) : (
              <span className="text-muted-foreground">{placeholder}</span>
            )}
          </Button>
        </PopoverTrigger>
        <PopoverContent className="w-auto p-0" align="start">
          <Calendar
            mode="single"
            selected={value}
            onSelect={(date) => {
              onChange(date);
              setOpen(false);
            }}
            locale={es}
            initialFocus
          />

          {showPresets && (
            <div className="border-t border-gray-200 p-3">
              <div className="space-y-2">
                {presets.map((preset) => (
                  <Button
                    key={preset.label}
                    variant="outline"
                    size="sm"
                    className="w-full justify-start text-left font-normal"
                    onClick={() => {
                      onChange(preset.value);
                      setOpen(false);
                    }}
                  >
                    {preset.label}
                  </Button>
                ))}
              </div>
            </div>
          )}
        </PopoverContent>
      </Popover>
    </div>
  );
}
