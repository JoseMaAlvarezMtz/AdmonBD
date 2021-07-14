const uri = 'https://localhost:44390/api/Distribucion';

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
                { data: "idClavemateria" },
                { data: "nombreClave" },
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
    let id = document.getElementById("").value;
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
    const inputIdDistribucion = document.getElementById("").value;
    const inputIdPlan = document.getElementById("").value;
    const inputIdClavemateria = document.getElementById("").value;
    const inputIdMateria = document.getElementById("").value;
    const inputIdGrupo = document.getElementById("").value;
    const inputIdHora = document.getElementById("").value;
    const inputIdDia = document.getElementById("").value;
    const inputIdSalon = document.getElementById("").value;
    const inputSemestre = document.getElementById("").value;
    obj = {
        "IdDistribucion": inputIdDistribucion,
        "IdPlan": inputIdPlan,
        "IdClavemateria": inputIdClavemateria,
        "IdMateria": inputIdMateria,
        "IdGrupo": inputIdGrupo,
        "IdHora": inputIdHora,
        "IdDia": inputIdDia,
        "IdSalon": inputIdSalon,
        "Semestre": inputSemestre
    }
    fetch(uri,{
        method: 'POST',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj)
    })
    .then(response => response.text())
    .then(data => Mensaje(data))
    .catch(error => console.error('Unable to Agregar Item.',error));
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
    const inputIdClavemateria = document.getElementById("").value;
    let url = uri + "/" + inputIdClavemateria
    fetch(url,{method:'DELETE'})
    .then(response => response.text())
    .then(data => Mensaje(data))
    .catch(error => console.error('Unable to Eliminar Item',error));
}
//----------------------------------------------------------------------------------------------------------------------------------------------------
//FUNCION PARA EDITAR UN ITEM EN LA BASE DE DATOS
function Editar(){
    const inputIdDistribucion = document.getElementById("").value;
    const inputIdPlan = document.getElementById("").value;
    const inputIdClavemateria = document.getElementById("").value;
    const inputIdMateria = document.getElementById("").value;
    const inputIdGrupo = document.getElementById("").value;
    const inputIdHora = document.getElementById("").value;
    const inputIdDia = document.getElementById("").value;
    const inputIdSalon = document.getElementById("").value;
    const inputSemestre = document.getElementById("").value;
    obj = {
        "IdDistribucion": inputIdDistribucion,
        "IdPlan": inputIdPlan,
        "IdClavemateria": inputIdClavemateria,
        "IdMateria": inputIdMateria,
        "IdGrupo": inputIdGrupo,
        "IdHora": inputIdHora,
        "IdDia": inputIdDia,
        "IdSalon": inputIdSalon,
        "Semestre": inputSemestre
    }
    fetch(uri,{
        method: 'PUT',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj)
    })
    .then(response => response.text())
    .then(data => Mensaje(data))
    .catch(error => console.error('Unable to Editar Item.',error));
}