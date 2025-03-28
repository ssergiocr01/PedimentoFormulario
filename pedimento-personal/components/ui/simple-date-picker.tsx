"use client";

import * as React from "react";
import { format } from "date-fns";
import { es } from "date-fns/locale";
import { CalendarIcon } from "lucide-react";

import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import { Calendar } from "@/components/ui/calendar";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";

interface DatePickerProps {
  value?: Date;
  onChange: (date: Date | undefined) => void;
  placeholder?: string;
}

export function SimpleDatePicker({
  value,
  onChange,
  placeholder = "Seleccionar fecha",
}: DatePickerProps) {
  const [calendarDate, setCalendarDate] = React.useState<Date | undefined>(
    value || new Date()
  );

  // Generar años para el selector (30 años atrás y 10 años adelante)
  const currentYear = new Date().getFullYear();
  const years = Array.from({ length: 41 }, (_, i) => currentYear - 30 + i);

  // Meses en español
  const months = [
    "Enero",
    "Febrero",
    "Marzo",
    "Abril",
    "Mayo",
    "Junio",
    "Julio",
    "Agosto",
    "Septiembre",
    "Octubre",
    "Noviembre",
    "Diciembre",
  ];

  // Manejar cambio de año
  const handleYearChange = (year: string) => {
    const newDate = new Date(calendarDate || new Date());
    newDate.setFullYear(Number.parseInt(year));
    setCalendarDate(newDate);
  };

  // Manejar cambio de mes
  const handleMonthChange = (month: string) => {
    const newDate = new Date(calendarDate || new Date());
    newDate.setMonth(Number.parseInt(month));
    setCalendarDate(newDate);
  };

  return (
    <Popover>
      <PopoverTrigger asChild>
        <Button
          variant="outline"
          className={cn(
            "w-full justify-start text-left font-normal",
            !value && "text-muted-foreground"
          )}
        >
          <CalendarIcon className="mr-2 h-4 w-4" />
          {value ? (
            format(value, "dd/MM/yyyy", { locale: es })
          ) : (
            <span>{placeholder}</span>
          )}
        </Button>
      </PopoverTrigger>
      <PopoverContent className="w-auto p-0" align="start">
        <div className="flex items-center justify-between p-3 border-b border-border">
          <div className="flex items-center gap-2">
            <Select
              value={
                calendarDate
                  ? calendarDate.getMonth().toString()
                  : new Date().getMonth().toString()
              }
              onValueChange={handleMonthChange}
            >
              <SelectTrigger className="w-[110px] h-8">
                <SelectValue placeholder="Mes" />
              </SelectTrigger>
              <SelectContent>
                {months.map((month, index) => (
                  <SelectItem key={month} value={index.toString()}>
                    {month}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>

            <Select
              value={
                calendarDate
                  ? calendarDate.getFullYear().toString()
                  : new Date().getFullYear().toString()
              }
              onValueChange={handleYearChange}
            >
              <SelectTrigger className="w-[90px] h-8">
                <SelectValue placeholder="Año" />
              </SelectTrigger>
              <SelectContent>
                {years.map((year) => (
                  <SelectItem key={year} value={year.toString()}>
                    {year}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>
        </div>

        <Calendar
          mode="single"
          selected={value}
          onSelect={onChange}
          month={calendarDate}
          onMonthChange={setCalendarDate}
          initialFocus
          locale={es}
        />

        <div className="p-3 border-t border-border">
          <div className="grid grid-cols-2 gap-2">
            <Button
              variant="outline"
              size="sm"
              onClick={() => onChange(new Date())}
            >
              Hoy
            </Button>
            <Button
              variant="outline"
              size="sm"
              onClick={() => {
                const yesterday = new Date();
                yesterday.setDate(yesterday.getDate() - 1);
                onChange(yesterday);
              }}
            >
              Ayer
            </Button>
            <Button
              variant="outline"
              size="sm"
              className="col-span-2"
              onClick={() => onChange(undefined)}
            >
              Limpiar
            </Button>
          </div>
        </div>
      </PopoverContent>
    </Popover>
  );
}
