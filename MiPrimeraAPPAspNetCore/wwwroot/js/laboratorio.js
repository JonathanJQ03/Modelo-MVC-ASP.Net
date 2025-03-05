window.onload = function () {
    listarLaboratorios();
}

let objLaboratorio;
async function listarLaboratorios() {
    objLaboratorio = {
        url: "Laboratorio/ListarLaboratorios",
        cabeceras: ["Id Laboratorio", "Nombre", "Direccion", "Persona a Cargo"],
        propiedades: ["iidlaboratorio", "nombre", "direccion", "personacontacto"],
        divContenedorTabla: "divContenedorTabla",
        propiedadID: "iidlaboratorio",
        editar: true,
        eliminar: true
    }

    pintar(objLaboratorio);
}

function BuscarLaboratorio() {
    let forma = document.getElementById("frmBusqueda");
    //Constructor que nos trae toda la informacion 
    let frm = new FormData(forma);

    fetchPost("Laboratorio/filtrarLaboratorios", "json", frm, function (res) {
        document.getElementById("divContenedorTabla").innerHTML = generarTabla(res);
    });
}

function LimpiarLaboratorio() {
    document.getElementById("nombre").value = "";
    document.getElementById("direccion").value = "";
    document.getElementById("personacontacto").value = "";

    if (document.getElementById("iidlaboratorio")) {
        document.getElementById("iidlaboratorio").value = "0";
    }

    document.getElementById("modalLaboratorioLabel").textContent = "Agregar Laboratorio";

    if (document.getElementById("btnGuardar")) {
        document.getElementById("btnGuardar").style.display = "";
    }

    if (document.getElementById("btnActualizar")) {
        document.getElementById("btnActualizar").style.display = "none";
    }

    listarLaboratorios();
}

function GuardarLaboratorio() {
    // Llamamos a la función confirmación antes de continuar con la lógica de guardar
    confirmacionGuardar().then((result) => {
        // Si el usuario confirma, guardamos el laboratorio
        if (result) {
            let forma = document.getElementById("frmLaboratorio");
            // Constructor que nos trae toda la información
            let frm = new FormData(forma);

            fetchPost("Laboratorio/GuardarLaboratorio", "text", frm, function (res) {
                // Limpiar formulario y los datos después de guardar
                LimpiarLaboratorio();
                LimpiarDatos("frmLaboratorio");

                // Cerrar el modal manualmente
                let modalElement = document.getElementById('modalLaboratorio');
                let modal = bootstrap.Modal.getInstance(modalElement);
                if (modal) {
                    modal.hide();
                }
            });
        } else {
            // Si el usuario no confirma (deniega), puedes mostrar un mensaje o no hacer nada
            Swal.fire("Los datos no han sido guardados", "", "info");
        }
    });
}

function Editar(id) {
    fetchGet("Laboratorio/RecuperarLaboratorio/?iidlaboratorio=" + id, "json", function (data) {
        if (!document.getElementById("iidlaboratorio")) {
            let inputId = document.createElement("input");
            inputId.type = "hidden";
            inputId.id = "iidlaboratorio";
            inputId.name = "iidlaboratorio";
            document.getElementById("frmLaboratorio").appendChild(inputId);
        }

        document.getElementById("iidlaboratorio").value = id;
        document.getElementById("nombre").value = data.nombre;
        document.getElementById("direccion").value = data.direccion;
        document.getElementById("personacontacto").value = data.personacontacto;

        document.getElementById("modalLaboratorioLabel").textContent = "Editar Laboratorio";

        if (!document.getElementById("btnActualizar")) {
            let btnActualizar = document.createElement("button");
            btnActualizar.type = "button";
            btnActualizar.id = "btnActualizar";
            btnActualizar.className = "btn btn-success";
            btnActualizar.textContent = "Actualizar";
            btnActualizar.onclick = function () { ActualizarCambiosLaboratorio(); };

            let footer = document.querySelector("#modalLaboratorio .modal-footer");
            footer.appendChild(btnActualizar);
        } else {
            document.getElementById("btnActualizar").style.display = "";
        }

        if (document.getElementById("btnGuardar")) {
            document.getElementById("btnGuardar").style.display = "none";
        }

        let modalElement = document.getElementById('modalLaboratorio');
        let modal = new bootstrap.Modal(modalElement);
        modal.show();
    });
}

function ActualizarCambiosLaboratorio() {
    let id = document.getElementById("iidlaboratorio").value;
    let nombre = document.getElementById("nombre").value;
    let direccion = document.getElementById("direccion").value;
    let personacontacto = document.getElementById("personacontacto").value;

    let frm = new FormData();
    frm.append("iidlaboratorio", id);
    frm.append("nombre", nombre);
    frm.append("direccion", direccion);
    frm.append("personacontacto", personacontacto);

    fetchPut("Laboratorio/ActualizarLaboratorio", "text", frm, function (data) {
        Swal.fire({
            title: "Actualizado!",
            text: `Los datos del laboratorio con ID ${id} se actualizaron correctamente`,
            icon: "success"
        });

        let modalElement = document.getElementById('modalLaboratorio');
        let modal = bootstrap.Modal.getInstance(modalElement);
        if (modal) {
            modal.hide();
        }

        LimpiarLaboratorio();
    });
}

function Eliminar(id) {
    // Primero, confirmamos la eliminación utilizando la función genérica
    confirmarEliminacion().then((result) => {
        if (result) {
            // Si el usuario confirma la eliminación, ejecutamos el código específico para eliminar el laboratorio
            let frm = new FormData();
            frm.append("iidmedicamento", id);

            fetchPost("Medicamento/EliminarMedicamento", "json", frm, function (data) {
                if (data > 0) {
                    Swal.fire({
                        title: "Eliminado!",
                        text: `El medicamento con el id: ${id} ha sido eliminado con éxito.`,
                        icon: "success"
                    });
                    ListarMedicamento();  // Refresca la lista de laboratorios
                } else {
                    Swal.fire({
                        title: "Error",
                        text: "Hubo un problema al eliminar el medicamento.",
                        icon: "error"
                    });
                }
            });
        }
    });
}
