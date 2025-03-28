export interface ClaseOption {
  cod_clase: string;
  cod_estrato: string;
  cod_clase_gen: string;
  cod_clas_ia: string;
  grupo: string;
  cod_institucion: string;
  titulo_de_la_clase: string;
  nivel_salarial: string;
  resolucion: string;
  fecha_res: string;
  gaceta: string;
  fecha_gaceta: string;
  vinculo_doc_pdf: string;
  activo: string;
  usuarioreg: string;
  fechareg: string;
  usuariomod: string;
  fechamod: string;
}

export const claseOptions: ClaseOption[] = [
  {
    cod_clase: "101370045",
    cod_estrato: "1",
    cod_clase_gen: "1",
    cod_clas_ia: "370",
    grupo: "999",
    cod_institucion: "13",
    titulo_de_la_clase: "Trabajador Operativo 1-INA (G. de E)",
    nivel_salarial: "45",
    resolucion: "DG-148-2017",
    fecha_res: "25/09/2017",
    gaceta: "6",
    fecha_gaceta: "15/01/2018",
    vinculo_doc_pdf: "docs_pdf/Trabajador Operativo 1-INA (G de E).pdf",
    activo: "0",
    usuarioreg: "sa",
    fechareg: "2018-01-23 13:25:04.043",
    usuariomod: "sa",
    fechamod: "2018-02-06 11:30:44.837"
  },
  {
    cod_clase: "101372090",
    cod_estrato: "1",
    cod_clase_gen: "1",
    cod_clas_ia: "372",
    grupo: "999",
    cod_institucion: "13",
    titulo_de_la_clase: "Conductor del INA",
    nivel_salarial: "90",
    resolucion: "DG-148-2017",
    fecha_res: "25/09/2017",
    gaceta: "6",
    fecha_gaceta: "15/01/2018",
    vinculo_doc_pdf: "docs_pdf/Conductor del INA.pdf",
    activo: "0",
    usuarioreg: "sa",
    fechareg: "2018-01-24 07:41:52.560",
    usuariomod: "sa",
    fechamod: "2018-02-06 11:27:15.133"
  },
  // Añade el resto de los registros aquí...
];

