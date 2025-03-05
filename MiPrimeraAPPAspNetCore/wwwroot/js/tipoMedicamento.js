window.onload = function () {
    listarTipoMedicamento();
}
function filtrarTipoMedicamento() {
    let nombre = document.getElementById("txtNombreTipoMedicamento").value; 

    if (nombre === "") { 
        listarTipoMedicamento();
    } else { 
        objTipoMedicamento.url = "TipoMedicamento/FiltrartipoMedicamento/?nombre=" + nombre
        pintar(objTipoMedicamento);
    }
}


let objTipoMedicamento;

async function listarTipoMedicamento() {

    objTipoMedicamento = {
        url: "TipoMedicamento/ListartipoMedicamento",
        cabeceras: ["Id tipo Medicamento", "Nombre", "Descripcion"],
        propiedades: ["idTipoMedicamento", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadID: "idTipoMedicamento"
    }

    pintar(objTipoMedicamento);
}

function BuscarTipoMedicamento() {
    let forma = document.getElementById("frmGuardarTipoMedicamento");
    //Constructor que nos trae toda la informacion 
    let frm = new FormData(forma);

    fetchGet("TipoMedicamento/RecuperarTipoMedicamento/?idTipoMedicamento=" + id, "json", function (data) {
        // Asignas los valores recuperados a los campos del formulario
        setN("idTipoMedicamento", data.idTipoMedicamento);
        setN("nombre", data.nombre);
        setN("descripcion", data.descripcion);
    });
}
function Buscar() {
    //let nombreTipoMedicamento = document.getElementById("txtNombreTipoMedicamento").value;
    get("txtNombreTipoMedicamento");
    //objTipoMedicamento.url = "TipoMedicamento/FiltrartipoMedicamento/?nombre=" + nombreTipoMedicamento,
    //    pintar(objTipoMedicamento);
}

function LimpiarTipoMedicamento() {

    document.getElementsByName("nombre")[0].value = "";
    document.getElementsByName("descripcion")[0].value = "";
    listarTipoMedicamento();

}

function GuardarTipoMedicamento()
{
    let forma = document.getElementById("frmGuardarTipoMedicamento");
    //Constructor que nos trae toda la informacion 
    //envio como parametro los datos
    let frm = new FormData(forma);

    fetchPost("TipoMedicamento/GuardarTipoMedicamento", "text", frm, function (res) {
        limpiarTipoMedicamento();
        LimpiarDatos("frmGuardarTipoMedicamento");
    });

}
function Editar(id) {
    // Primero, recuperas los datos del medicamento por su ID
    fetchGet("TipoMedicamento/RecuperarTipoMedicamento/?idtipomedicamento=" + id, "json", function (data) {
        // Asignas los valores recuperados a los campos del formulario
        setN("idTipoMedicamento", data.idTipoMedicamento);
        setN("nombre", data.nombre);
        setN("descripcion", data.descripcion);
    });

}

function ActualizarCambiosTipoMedicamento() {
        let id = document.getElementById("idTipoMedicamento").value;
        let nombre = document.getElementById("nombre").value;
        let descripcion = document.getElementById("descripcion").value;
        let frm = new FormData();
        frm.append("idTipoMedicamento", id);
        frm.append("nombre", nombre);
        frm.append("descripcion", descripcion);
        fetchPut("TipoMedicamento/ActualizarTipoMedicamento", "text", frm, function (data) {
            alert(`Los datos del id ${id} se actualizaron correctamente`);
            listarTipoMedicamento(); 

            LimpiarTipoMedicamento();
        });
    
}

function Eliminar(id) {
    let frm = new FormData();
    frm.append("idTipoMedicamento", id);

    fetchPost("TipoMedicamento/EliminarTipoMedicamento", "json", frm, function (data) {
        if (data > 0) {
            alert(`Medicamento con el id: ${id}, eliminado con éxito !!!`);
            listarTipoMedicamento();
        } else {
            alert("Hubo un problema al eliminar el tipo de medicamento.");
        }
    });
}
