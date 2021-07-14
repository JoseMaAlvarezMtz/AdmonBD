const uri = 'https://localhost:44390/api/Distribucion';

//FUNCIONES PARA CONSULTAR INDIVIDUAL Y TODOS LOS ELEMENTOS
//Pendiente modificar los ElementByID porque faltan referencias
$(function(){
    getItems();
    getSelects();
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
                { data: "idDistribucion" },
                { data: "plan" },
                { data: "clavemateria" },
                { data: "materia" },
                { data: "grupo" },
                { data: "hora" },
                { data: "dia" },
                { data: "salon" },
                { data: "semestrecadena" },

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
    /*$('#iddistribucion').val(data.idDistribucion);
    $('#plan').val(data.plan);
    $('#clavemateria').val(data.clavemateria);
    $('#materia').val(data.materia);
    $('#grupo').val(data.grupo);
    $('#hora').val(data.hora);
    $('#dia').val(data.dia);
    $('#salon').val(data.salon);
    $('#semestre').val(data.semestrecadena);*/
    //PENDIENTE DE TERMINAR
}

function getSelects(){
    const ClaveMateria = 'https://localhost:44390/api/ClaveMateria';
    fetch(ClaveMateria)
    .then(response => response.json())
    .then(data => {    })
    .catch(error => console.error('Unable to get items.', error));

    const Dia = 'https://localhost:44390/api/Dia';
    fetch(Dia)
    .then(response => response.json())
    .then(data => {    })
    .catch(error => console.error('Unable to get items.', error));

    const Grupo = 'https://localhost:44390/api/Grupo';
    fetch(Grupo)
    .then(response => response.json())
    .then(data => {    })
    .catch(error => console.error('Unable to get items.', error));

    const Hora = 'https://localhost:44390/api/Hora';
    fetch(Hora)
    .then(response => response.json())
    .then(data => {    })
    .catch(error => console.error('Unable to get items.', error));

    const Materia = 'https://localhost:44390/api/Materia';
    fetch(Materia)
    .then(response => response.json())
    .then(data => {    })
    .catch(error => console.error('Unable to get items.', error));

    const PlanEstudios = 'https://localhost:44390/api/PlanEstudios';
    fetch(PlanEstudios)
    .then(response => response.json())
    .then(data => {    })
    .catch(error => console.error('Unable to get items.', error));

    const Salon = 'https://localhost:44390/api/Salon';
    fetch(Salon)
    .then(response => response.json())
    .then(data => {    })
    .catch(error => console.error('Unable to get items.', error));

    const Semestre = 'https://localhost:44390/api/Semestre';
    fetch(Semestre)
    .then(response => response.json())
    .then(data => {    })
    .catch(error => console.error('Unable to get items.', error));
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
    location.reload();
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