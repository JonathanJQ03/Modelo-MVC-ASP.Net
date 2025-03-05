function get(idControl)
{
    return document.getElementById(idControl).value;
}
function set(idControl,valor)
{
     return document.getElementById(idControl).value = valor;
}

function setN(namecontrol, valor) {
    document.getElementsByName(namecontrol)[0].value = valor;
}

function getN(namecontrol)
{
    return document.getElementById(namecontrol)[0].value;
}

function LimpiarDatos(idFormulario) {
    document.getElementById(idFormulario).reset();
}




async function fetchGet(url, tipoRespuesta, callback) {
    try {
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + url;
        let res = await fetch(urlCompleta)

        if (tipoRespuesta == "json")
            res = await res.json();
        else if (tipoRespuesta == "text")
            res = await res.text();

        callback(res)

    } catch (e) {
        alert("ERROR! Ocurre un problema.");
    }
}

//recibiremos como parametro el formulario
async function fetchPost(url, tipoRespuesta, frm, callback)
{
    try
    {
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + url;
        let res = await fetch(urlCompleta,
            {
                method: "POST",
                body: frm

            });
        if (tipoRespuesta == "json")
            res = await res.json();
        else if (tipoRespuesta == "text")
            res = await res.text();

        callback(res)
    } catch (e) {
        alert("Ocurrio un problema en el POST")
    }
}
async function fetchPut(url, tipoRespuesta, frm, callback) {

    try {
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + url;
        let res = await fetch(urlCompleta,
            {
                method: "PUT",
                body: frm

            });
        if (tipoRespuesta == "json")
            res = await res.json();
        else if (tipoRespuesta == "text")
            res = await res.text();
        callback(res)
    } catch
    {
        alert("Ocurrio un problema en el PUT")
    }
    
}

let objConfiguracionGlobal;

//{url: "", cabeceras:[], propiedades:[]}
function pintar(objConfiguracion) {
    objConfiguracionGlobal = objConfiguracion;


    if (objConfiguracionGlobal.divContenedeorTabla == undefined)
    {
        objConfiguracionGlobal.divContenedeorTabla = "divContenedorTabla";
    }
    if (objConfiguracionGlobal.editar == undefined) {
        objConfiguracionGlobal.editar = false;
    }
    if (objConfiguracionGlobal.eliminar == undefined) {
        objConfiguracionGlobal.eliminar = false;
    }
    if(objConfiguracionGlobal.propiedadID == undefined) {
        objConfiguracionGlobal.propiedadID = false;
    }
    if (objConfiguracionGlobal.actualizar == undefined) {
        objConfiguracionGlobal.actualizar = false;
    }
    fetchGet(objConfiguracion.url, "json", function (res) {

        let contenido = "";

        contenido += "<div id='divContenedorTabla'>";

        contenido += generarTabla(res);

        contenido += "</div>";

        document.getElementById("divTabla").innerHTML = contenido;
    })
}

function generarTabla(res) {
    let contenido = "";

    //["Id tipo Medicamento", "Nombre", "Descripcion", "Stock"]
    let cabeceras = objConfiguracionGlobal.cabeceras;
    let propiedades = objConfiguracionGlobal.propiedades;

    contenido += "<table class='table'>";
    contenido += "<thead>";
    contenido += "<tr>";

    for (let i = 0; i < cabeceras.length; i++) {
        contenido += "<th>" + cabeceras[i] + "</th>";
    }
    contenido += "</tr>";
    contenido += "</thead>";

    let nroRegistros = res.length;
    let obj;
    let propiedadActual;

    contenido += "<tbody>";

    for (let i = 0; i < nroRegistros; i++) {
        obj = res[i];
        contenido += "<tr>";
        for (let j = 0; j < propiedades.length; j++) {
            propiedadActual = propiedades[j];
            contenido += "<td>" + obj[propiedadActual] + "</td>";
        }
        if (objConfiguracionGlobal.editar == true || objConfiguracionGlobal.eliminar == true) {
            //recibo el elemento desde el obj de configuracion global y acordarme las condiciones
            let propiedadID = objConfiguracionGlobal.propiedadID;
            contenido += "<td>";
            if (objConfiguracionGlobal.editar == true) {
                //Recordar q dentro del evento podemos enviar parametros
                contenido += `<i class="btn btn-primary" onclick = "Editar(${obj[propiedadID]})"  style="margin-right: 15px;" ><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                    <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
                 </svg></i>`

            }
            if (objConfiguracionGlobal.eliminar == true) {
                contenido += `<i class="btn btn-danger" onclick = "Eliminar(${obj[propiedadID]})" ><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
                  <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5m3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0z"/>
                  <path d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4zM2.5 3h11V2h-11z"/>
                </svg></i>`
            }
            contenido += "</td>";
        }
        contenido += "</tr>";
    }

    contenido += "</tbody>";
    contenido += "</table>";

    return contenido;
}

function confirmacionGuardar() {
    return Swal.fire({
        title: "Estas seguro de guardar la información?",
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: "Guardar",
        denyButtonText: `No Guardar`
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire("Guardado!", "", "Los datos se han guardado con exito");
            return true;  // Retorna verdadero si se confirma el guardado
        } else if (result.isDenied) {
            Swal.fire("Los datos no han sido guardado", "", "info");
            return false; // Retorna falso si se niega el guardado
        }
    });
}

function confirmarEliminacion() {
    return new Promise((resolve, reject) => {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                cancelButton: "btn btn-danger",
                confirmButton: "btn btn-success"
                
            },
            buttonsStyling: false
        });

        swalWithBootstrapButtons.fire({
            title: "Estas seguro de eliminar este elemento?",
            text: "No se pueden revertir los cambios!",
            icon: "Peligro!",
            showCancelButton: true,
            confirmButtonText: "Si, eliminalo!",
            cancelButtonText: "No, cancelalo!",
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                swalWithBootstrapButtons.fire({
                    title: "Eliminado!",
                    text: "Tu elemento ha sido eliminado con exito.",
                    icon: "Completado"
                });
                resolve(true);  // El usuario confirmó la eliminación
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                swalWithBootstrapButtons.fire({
                    title: "Cancelado",
                    text: "Your imaginary file is safe :)",
                    icon: "error"
                });
                resolve(false);  // El usuario canceló la eliminación
            }
        });
    });
}



//crearme una funcion la cual va a tener el codigo del modal: funcion nombre(titulo) y pasar ese elemento como parametro y tmn un 
//callback esta usando en las promesas  y la promera debe tener un return al inicio
//Exito es una funcion q va a va servirme para eliminar los modales
// podemos usar el cnd previamente, y el js en el script de modo que 
        //lo usamos desde el depurar o minimizado para js como csss para usarlo