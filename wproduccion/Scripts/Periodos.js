function periodosagno (objeto, startYear, endYear, startMonth, endMonth) {
    for (let year = startYear; year <= endYear; year++) {
        let monthStart = (year === startYear) ? startMonth : 1;
        let monthEnd = (year === endYear) ? endMonth : 12;

        for (let month = monthStart; month <= monthEnd; month++) {
            let monthStr = month.toString().padStart(2, '0');
            let optionValue = `${monthStr}-${year}`;
            let optionText = `${monthStr}-${year}`;
            let optionElement = document.createElement('option');
            optionElement.value = optionValue;
            optionElement.textContent = optionText;
            optionElement.setAttribute('dataagno', `${year}`);
            //if (startYear === 2024 && month === 9) {
            //    optionElement.selected = true; // Opción predeterminada
            //}

            objeto.appendChild(optionElement);
        }
    }

}

 function verificarBloqueo() {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: "/VersionData/VerificarBloqueo",
            type: 'GET',
            dataType: 'json',
            success: function (data) {
               
                if (data.error.NumError == "0") {
                    if (data.error.bloqueado === "S") {
                        resolve("S");
                    } else if (data.error.bloqueado === "N") {
                        resolve("N");
                    } else {
                        resolve('No se pudo determinar el estado del bloqueo.');
                    }
                } else {
                    resolve("Ha ocurrido un error al intentar verificar el bloqueo.");
                }
            },
            error: function (xhr, status, error) {
                reject("Ha ocurrido un error al intentar verificar el bloqueo.");
            }
        });
    });
}