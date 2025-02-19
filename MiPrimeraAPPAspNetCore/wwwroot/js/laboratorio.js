window.onload = function () {
    listarLaboratorios();
}

let objLaboratorio;
async function listarLaboratorios() {

    objLaboratorio = {
        url: "Laboratorio/ListarLaboratorios",
        cabeceras: ["Id Laboratorio", "Nombre", "Direccion", "Persona a Cargo"],
        propiedades: ["iddlaboratorio", "nombre", "direccion","personacontacto"],
        divContenedorTabla : "divContenedorTabla"
    }
   

    pintar(objLaboratorio);
}

function BuscarLaboratorio()
{
    let forma = document.getElementById("frmBusqueda");
    //Constructor que nos trae toda la informacion 
    let frm = new FormData(forma);

    fetchPost("Laboratorio/filtrarLaboratorios", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    });
}

function LimpiarLaboratorio() {

    document.getElementsByName("nombre")[0].value = "";
    document.getElementsByName("direccion")[0].value = "";
    document.getElementsByName("personacontacto")[0].value = "";
    listarLaboratorios();
}


//function Buscar() {
//    //let nombreTipoMedicamento = document.getElementById("txtNombreTipoMedicamento").value;
//    get("txtLaboratorio");
//    //objTipoMedicamento.url = "TipoMedicamento/FiltrartipoMedicamento/?nombre=" + nombreTipoMedicamento,
//    //    pintar(objTipoMedicamento);
//}

//function Limpiar() {
//    listarTipoMedicamento();
//    set("txtLaboratorio", "");
//    //document.getElementById("txtNombreTipoMedicamento").value = "";
//}