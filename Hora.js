const uri = 'https://localhost:44390/api/Hora';

//FUNCIONES PARA CONSULTAR INDIVIDUAL Y TODOS LOS ELEMENTOS
//Pendiente modificar los ElementByID porque faltan referencias
function getItems() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data){
    console.log(data);
    //PENDIENTE DE TERMINAR
}

function ConsultaPorId(){
    let id = document.getElementById("nombreclave").value;
    let url = uri + '/'+ id;
    fetch(url)
    .then(response => response.json())
    .then(data => llenarCampos(data))
    .catch(error => console.error('Unable to Consulta Por Id', error));
}

function llenarCampos(data){
    console.log(data.nombreClave);
    console.log(data.idClavemateria);
    console.log(data.descripcion);
    //PENDIENTE DE TERMINAR
}
//-------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCIONES PARA AGREGAR UN ITEM EN LA BASE DE DATOS
//Pendiente modificar los ElementByID porque faltan referencias
function Agregar(){
    const inputDescripcion = document.getElementById("descripcion").value;
    const inputNombreClave = document.getElementById("nombreclave").value;
    objClaveMateria = {
        "Descripcion": inputDescripcion,
        "NombreClave": inputNombreClave
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
}
//----------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCIONES PARA ELIMINAR UN ITEM EN LA BASE DE DATOS
//Pendiente modificar los ElementByID porque faltan referencias
function Eliminar(){
    const inputIdClavemateria = document.getElementById("nombreclave").value;
    let url = uri + "/" + inputIdClavemateria
    fetch(url,{method:'DELETE'})
    .then(response => response.text())
    .then(data => Mensaje(data))
    .catch(error => console.error('Unable to Eliminar Item',error));
}
//----------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCION PARA EDITAR UN ITEM EN LA BASE DE DATOS
function Editar(){
    const inputDescripcion = document.getElementById("descripcion").value;
    const inputNombreClave = document.getElementById("nombreclave").value;
    objClaveMateria = {
        "Descripcion": inputDescripcion,
        "NombreClave": inputNombreClave
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