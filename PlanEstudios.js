const uri = 'https://localhost:44390/api/PlanEstudios';

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
                { data: "idPlan" },
                { data: "clavePlan" },
                { data: "descripcion" }

            ]
        });
    });
    $('#tabla tbody').on('click', 'tr', function () {
    var data = $('#tabla').DataTable().row(this).data();
    llenarCampos(data);
} );
}

function ConsultaPorId(){
    let id = document.getElementById("idplan").value;
    let url = uri + '/'+ id;
    fetch(url)
    .then(response => response.json())
    .then(data => llenarCampos(data))
    .catch(error => console.error('Unable to Consulta Por Id', error));
}

function llenarCampos(data){
    $('#idplan').val(data.idPlan);
    $('#claveplan').val(data.clavePlan);
    $('#descripcion').val(data.descripcion);
    //PENDIENTE DE TERMINAR
}
//-------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCIONES PARA AGREGAR UN ITEM EN LA BASE DE DATOS
//Pendiente modificar los ElementByID porque faltan referencias
function Agregar(){
    const inputDescripcion = document.getElementById("descripcion").value;
    const inputClavePlan = document.getElementById("claveplan").value;
    objClaveMateria = {
        "Descripcion": inputDescripcion,
        "ClavePlan": inputClavePlan
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
    .catch(error => console.error('Unable to Agregar Item.',error ,objClaveMateria));
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
    const inputIdClavemateria = document.getElementById("idplan").value;
    let url = uri + "/" + inputIdClavemateria
    fetch(url,{method:'DELETE'})
    .then(response => response.text())
    .then(data => Mensaje(data))
    .catch(error => console.error('Unable to Eliminar Item',error));
}
//----------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCION PARA EDITAR UN ITEM EN LA BASE DE DATOS
function Editar(){
    const inputIdPlan = document.getElementById("idplan").value;
    const inputDescripcion = document.getElementById("descripcion").value;
    const inputClavePlan = document.getElementById("claveplan").value;
    objClaveMateria = {
        "IdPlan": inputIdPlan,
        "Descripcion": inputDescripcion,
        "ClavePlan": inputClavePlan
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