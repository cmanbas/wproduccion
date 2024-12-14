function cargadatafiles(idtiendacajapar, fechapar) {

 

            sourcefiles =
            {
                datatype: "json",
                datafields: [
                    { name: "correlativo", type: "number" },
                    { name: "tipo", dataField: "string" },
                    { name: "sfechaventa", dataField: "string" },
                    { name: "fechaventa", dataField: "date", cellsformat: "YYYY-MM-dd" },
                    { name: "idtiendacaja", type: "number" },
                    { name: "nombretienda", dataField: "string" },
                    { name: "observacion", dataField: "string" },
                    { name: "nombrearchivo", dataField: "string" },
                    { name: "urlarchivo", dataField: "string" },
                    { name: "tiendadebito", type: "number" },
                    { name: "tiendatcredito", type: "number" },
                    { name: "idtiendacaja", type: "number" },
                ],


                url: '/reporte/listafiles', data: {
                    idtiendacaja: idtiendacajapar,
                    fechadesde: fechapar

                }
    };

            return sourcefiles;

}

 