const uri = 'https://localhost:44390/api/Hora';

//FUNCIONES PARA CONSULTAR INDIVIDUAL Y TODOS LOS ELEMENTOS
//Pendiente modificar los ElementByID porque faltan referencias
$(function(){
    getItems();
});

function getItems() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data){
    console.log(data);
    //PENDIENTE DE TERMINAR
    Table = $(function(){
        $('#tabla').DataTable({
            data: data,
            columns:[
                { data: "idHora" },
                { data: "nombreHora" },
                { data: "horaInicio" },
                { data: "horaFin" }
            ]
        });
    });
    $('#tabla tbody').on('click', 'tr', function () {
    var data = $('#tabla').DataTable().row(this).data();
    llenarCampos(data);
} );
}

function ConsultaPorId(){
    let id = document.getElementById("idhora").value;
    let url = uri + '/'+ id;
    fetch(url)
    .then(response => response.json())
    .then(data => llenarCampos(data))
    .catch(error => console.error('Unable to Consulta Por Id', error));
}

function llenarCampos(data){
    $('#idhora').val(data.idHora);
    $('#nombrehora').val(data.nombreHora);
    $('#horainicio').val(data.horaInicio);
    $('#horafin').val(data.horaFin);
    //PENDIENTE DE TERMINAR
}
//-------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCIONES PARA AGREGAR UN ITEM EN LA BASE DE DATOS
//Pendiente modificar los ElementByID porque faltan referencias
function Agregar(){
    const inputIdHora = document.getElementById("idhora").value;
    const inputNombreHora = document.getElementById("nombrehora").value;
    const inputHoraInicio = document.getElementById("horainicio").value;
    const inputHoraFin = document.getElementById("horafin").value;
    objClaveMateria = {
        "IdHora": inputIdHora,
        "NombreHora": inputNombreHora,
        "HoraInicio": inputHoraInicio,
        "HoraFin": inputHoraFin
    }
    fetch(uri,{
        method: 'POST',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(objClaveMateria)
    })
    .then(response => response.text())
    .then(data => Mensaje(data))
    .catch(error => console.error('Unable to Agregar Item.',error));
}
//----------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCION PARA IMPRIMIR MENSAJE DE ERROR O DE EXITO
function Mensaje(data){
    console.log(data);
    location.reload();
}
//----------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCIONES PARA ELIMINAR UN ITEM EN LA BASE DE DATOS
//Pendiente modificar los ElementByID porque faltan referencias
function Eliminar(){
    const inputIdClavemateria = document.getElementById("idhora").value;
    let url = uri + "/" + inputIdClavemateria
    fetch(url,{method:'DELETE'})
    .then(response => response.text())
    .then(data => Mensaje(data))
    .catch(error => console.error('Unable to Eliminar Item',error));
}
//----------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCION PARA EDITAR UN ITEM EN LA BASE DE DATOS
function Editar(){
    const inputIdHora = document.getElementById("idhora").value;
    const inputNombreHora = document.getElementById("nombrehora").value;
    const inputHoraInicio = document.getElementById("horainicio").value;
    const inputHoraFin = document.getElementById("horafin").value;
    objClaveMateria = {
        "IdHora": inputIdHora,
        "NombreHora": inputNombreHora,
        "HoraInicio": inputHoraInicio,
        "HoraFin": inputHoraFin
    }
    fetch(uri,{
        method: 'PUT',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(objClaveMateria)
    })
    .then(response => response.text())
    .then(data => Mensaje(data))
    .catch(error => console.error('Unable to Editar Item.',error ,objClaveMateria));
}