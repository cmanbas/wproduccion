function generatewindow() {
    $('#modalWindow').jqxWindow({
        autoOpen: false,
        height: 300,
        width: 330, cancelButton: $('#cancel'),
        resizable: false,
        modalOpacity: 0.3, isModal: true,
        initContent: function () {
            $('#ok').jqxButton({
                width: '120px'
            });
            $('#cancela').jqxButton({
                width: '120px'
            });
            $('#ok').focus();
        }
    });


    $("#ok").jqxButton({ theme: 'energyblue', template: "default" });
    $('#modalWindow').jqxWindow('show');
}
function onlyNumberKey(evt) {
 
    // Only ASCII character in that range allowed
    let ASCIICode = (evt.which) ? evt.which : evt.keyCode
    if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57))
        return false;
    return true;
}
function validaEntero(value) {
    var RegExPattern = /[0-9]+$/;
    return RegExPattern.test(value);
}
function formateaNumero(value) {

    if (validaEntero(value)) {
        var retorno = '';
        value = value.toString().split('').reverse().join('');
        var i = value.length;
        while (i > 0) retorno += ((i % 3 == 0 && i != value.length) ? '.' : '') + value.substring(i--, i);
        return retorno;
    }
    return value;
}
function imprime_numero(obj) {

    // Traspasa el valor a número entero
    var numero = document.getElementById(obj).value;
    numero = numero.split(".").join("");
    document.getElementById(obj).value = formateaNumero(numero);
}
function convertUnixDate(unixDateString) {
    
    if (unixDateString == "" || unixDateString === null) { 
        alert(unixDateString); return ""; }
 
    const unixTimeMilliseconds = parseInt(unixDateString.replace(/\/Date\((\d+)\)\//, '$1'), 10);

    // Create a new Date object using the Unix timestamp
    const date = new Date(unixTimeMilliseconds);

    return date;
}
function formatDate(date) {
   
    if (date == "" || date === null)
    {  return ""; }
 
    const year = date.getUTCFullYear();
    const month = String(date.getUTCMonth() + 1).padStart(2, '0');
    const day = String(date.getUTCDate()).padStart(2, '0');

    return `${year}-${month}-${day}`;
}