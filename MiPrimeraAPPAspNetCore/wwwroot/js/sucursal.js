window.onload = function () {
    listarSucursal();
}

let objSucursal;
async function listarSucursal() {
    
    objSucursal = {
        url: "Sucursal/ListarSucursal",
        cabeceras: ["Id Sucursal", "Nombre", "Direccion"],
        propiedades: ["idSucursal", "nombre", "direccion"],
        divContenedorTabla: "divContenedorTabla"
    }

    pintar(objSucursal);
}

function BuscarSucursal() {
    let forma = document.getElementById("frmSucursal");
    //Constructor que nos trae toda la informacion 
    let frm = new FormData(forma);

    fetchPost("Sucursal/FiltrarSucursal", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    });
}


function LimpiarSucursal() {

    document.getElementsByName("idSucursal")[0].value = "";
    document.getElementsByName("nombre")[0].value = "";
    document.getElementsByName("direccion")[0].value = "";
    listarSucursal();

 }
