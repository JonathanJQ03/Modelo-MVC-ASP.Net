window.onload = function () {
    listarTipoMedicamento();

}

let objMedicamento;

async function ListarMedicamento() {

    objMedicamento = {
        url: "Medicamento/ListarMedicamentos",
        cabeceras: ["Id Medicamento", "Nombre del Medicamento", "Nombre del Laboratorio", "Tipo de Medicamento"],
        propiedades: ["iidmedicamento", "nombremedicamento", "nombrelaboratorio", "nombretipomedicamento"],
        divContenedorTabla: "divContenedorTabla",
        propiedadID: "iidlaboratorio",
        editar: true,
        eliminar: true
    }

    pintar(objMedicamento);
}

function LimpiarMedicamento() {
    
    document.getElementById("nombremedicamento").value = "";
    document.getElementById("iidlaboratorio").value = "";
    document.getElementById("iidtipomedicamento").value = "";

    if (document.getElementById("iidmedicamento")) {
        document.getElementById("iidmedicamento").value = "0";
    }

    document.getElementById("modalMedicamentoLabel").textContent = "Agregar Medicamento";

    if (document.getElementById("btnGuardar")) {
        document.getElementById("btnGuardar").style.display = "";
    }

    if (document.getElementById("btnActualizar")) {
        document.getElementById("btnActualizar").style.display = "none";
    }
    ListarMedicamento();

}

function GuardarMedicamento() {
    // Llamamos a la función confirmación antes de continuar con la lógica de guardar
    confirmacionGuardar().then((result) => {
        // Si el usuario confirma, guardamos el laboratorio
        if (result) {
            let forma = document.getElementById("frmMedicamento");
            // Constructor que nos trae toda la información
            let frm = new FormData(forma);

            fetchPost("Medicamento/GuardarMedicamento", "text", frm, function (res) {
                // Limpiar formulario y los datos después de guardar
                LimpiarLaboratorio();
                LimpiarDatos("frmMedicamento");

                // Cerrar el modal manualmente
                let modalElement = document.getElementById('modalMedicamento');
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
    fetchGet("Medicamento/RecuperarMedicamento/?iidmedicamento=" + id, function (data) {
        // El input iidmedicamento ya existe en el formulario, no es necesario crearlo
        document.getElementById("iidmedicamento").value = id;
        document.getElementById("nombremedicamento").value = data.nombremedicamento;

        // Seleccionamos el laboratorio y tipo de medicamento correcto en los select
        // Suponiendo que los valores recibidos son IDs
        document.getElementById("iidlaboratorio").value = data.iidlaboratorio;
        document.getElementById("iidtipomedicamento").value = data.iidtipomedicamento;

        // Cambiamos el título del modal
        document.getElementById("modalMedicamentoLabel").textContent = "Editar Medicamento";

        // Creamos el botón de actualizar si no existe
        if (!document.getElementById("btnActualizar")) {
            let btnActualizar = document.createElement("button");
            btnActualizar.type = "button";
            btnActualizar.id = "btnActualizar";
            btnActualizar.className = "btn btn-success";
            btnActualizar.textContent = "Actualizar";
            btnActualizar.onclick = function () { ActualizarMedicamento(); }; // Nombre corregido
            let footer = document.querySelector("#modalMedicamento .modal-footer");
            footer.appendChild(btnActualizar);
        } else {
            document.getElementById("btnActualizar").style.display = "";
        }

        // Ocultamos el botón de guardar
        if (document.getElementById("btnGuardar")) {
            document.getElementById("btnGuardar").style.display = "none";
        }

        // Abrimos el modal de MEDICAMENTO (no de laboratorio)
        let modalElement = document.getElementById('modalMedicamento');
        let modal = new bootstrap.Modal(modalElement);
        modal.show();
    });
}

function ActualizarMedicamento() {
    let id = document.getElementById("iidmedicamento").value;
    let nombremedicamento = document.getElementById("nombremedicamento").value;
    let iidlaboratorio = document.getElementById("iidlaboratorio").value;
    let iidtipomedicamento = document.getElementById("iidtipomedicamento").value;

    let frm = new FormData();
    frm.append("iidmedicamento", id);
    frm.append("nombremedicamento", nombremedicamento);
    frm.append("iidlaboratorio", iidlaboratorio);
    frm.append("iidtipomedicamento", iidtipomedicamento);

    fetchPut("Medicamento/ActualizarMedicamento", frm, function (data) {
        Swal.fire({
            title: "Actualizado!",
            text: `Los datos del medicamento con ID ${id} se actualizaron correctamente`,
            icon: "success"
        });

        let modalElement = document.getElementById('modalMedicamento');
        let modal = bootstrap.Modal.getInstance(modalElement);
        if (modal) {
            modal.hide();
        }

        LimpiarMedicamento();
        listarMedicamento(); // Importante: actualizar la tabla después de modificar
    });
}
//llamo a la funcion envio los itutlos,  y todo esa va dentro de la funciones q implementan las acciones volviendo a llamar las funciones el callback
// es la respuesta

