function fcreaventanaotrospagoold() {
    const boxElem = document.getElementById("matriz");
 
    boxElem.innerHTML += `<div id="Wotrospagos" hidden style="box-shadow: inset 12px 6px 6px 0px #ffffff; background: linear-gradient(to bottom, #ffffff 5%, #f6f6f6 100%); background-color: #ffffff; border-radius: 7px; border: 2px solid #dcdcdc;">
        <div>
            <h5 id="tituloidy">Detalle Otros Pagos</h5>
        </div>
        <div id="divcuerpo" style=" display: table-cell; text-align: center; vertical-align: middle; background-color: lightyellow !important; font-size: 11px !important; font-family: Calibri !important;">

            <div style="margin:10px;">
                <table class="customTable" style="border-collapse: separate; border-spacing: 6px 6px; font-size:12px;">
                    <tr>
                        <td align="right">Giftcard:</td>
                        <td align="left"><input class="input" type="text" id="Giftcard" disabled /></td>
                    </tr>
                    <tr>
                        <td align="right">Pase compra:</td>
                        <td align="left"><input class="input" type="text" id="Pasecompra" disabled /></td>
                    </tr>
                    <tr>
                        <td align="right">Cupon:</td>
                        <td align="left"><input class="input" type="text" id="Cupon" disabled /></td>
                    </tr>
                    <tr>
                        <td align="right">Cheque:</td>
                        <td align="left"><input class="input" type="text" id="Cheque" disabled /></td>
                    </tr>
                    <tr>
                        <td align="right">Mercado pago:</td>
                        <td align="left"><input class="input" type="text" id="Mercadopago" disabled /></td>
                    </tr>
                    <tr>

                        <td colspan="2" style="padding-top: 10px;" align="center">

                            <input type="button" class="botondatableADD" value=" Salir " id="cancelButtonop" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>`;

}


function generatewotrospagos() {

    $('#WOtrosPagos').jqxWindow({
        height: 300,
        width: 280,
        autoOpen: false,
        isModal: true,
        modalOpacity: 0.3,
        resizable: false,
        cancelButton: $('#cancelButtonop'),
        initContent: function () {
         $('#cancelButtonop').jqxButton({ width: '80px', disabled: false });

        }
    });


}
function generatewcierres() {

    $('#modalCierres').jqxWindow({
        height: 420,
        width: 700,
        autoOpen: false,
        isModal: true,
        modalOpacity: 0.3,
        resizable: false,
        cancelButton: $('#cancelButtoncierre'),
        initContent: function () {
            $('#cancelButtoncierre').jqxButton({ width: '80px', disabled: false });

        }
    });


}