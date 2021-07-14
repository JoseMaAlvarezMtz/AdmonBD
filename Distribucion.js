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
    
}

function getSelects(){
    const ClaveMateria = 'https://localhost:44390/api/ClaveMateria';
    fetch(ClaveMateria)
    .then(response => response.json())
    .then(data => {  
        data.forEach(d => {
            var option = document.createElement("option");
            option.text = d.nombreClave;
            option.value = d.nombreClave;
            var select = document.querySelector(".selectClaveMateria");
            select.appendChild(option);
        });
    })
    .catch(error => console.error('Unable to get items.', error));

    const Dia = 'https://localhost:44390/api/Dia';
    fetch(Dia)
    .then(response => response.json())
    .then(data => {  
        data.forEach(d => {
            var option = document.createElement("option");
            option.text = d.claveDia;
            option.value = d.claveDia;
            var select = document.querySelector(".selectDia");
            select.appendChild(option);
        });
    })
    .catch(error => console.error('Unable to get items.', error));

    const Grupo = 'https://localhost:44390/api/Grupo';
    fetch(Grupo)
    .then(response => response.json())
    .then(data => {  
        data.forEach(d => {
            var option = document.createElement("option");
            option.text = d.numeroGrupo;
            option.value = d.numeroGrupo;
            var select = document.querySelector(".selectGrupo");
            select.appendChild(option);
        });
    })
    .catch(error => console.error('Unable to get items.', error));

    const Hora = 'https://localhost:44390/api/Hora';
    fetch(Hora)
    .then(response => response.json())
    .then(data => {  
        data.forEach(d => {
            var option = document.createElement("option");
            option.text = d.nombreHora;
            option.value = d.nombreHora;
            var select = document.querySelector(".selectHora");
            select.appendChild(option);
        });
    })
    .catch(error => console.error('Unable to get items.', error));

    const Materia = 'https://localhost:44390/api/Materia';
    fetch(Materia)
    .then(response => response.json())
    .then(data => {  
        data.forEach(d => {
            var option = document.createElement("option");
            option.text = d.nombreMateria;
            option.value = d.nombreMateria;
            var select = document.querySelector(".selectMateria");
            select.appendChild(option);
        });
    })
    .catch(error => console.error('Unable to get items.', error));

    const PlanEstudios = 'https://localhost:44390/api/PlanEstudios';
    fetch(PlanEstudios)
    .then(response => response.json())
    .then(data => {  
        data.forEach(d => {
            var option = document.createElement("option");
            option.text = d.clavePlan;
            option.value = d.clavePlan;
            var select = document.querySelector(".selectPlan");
            select.appendChild(option);
        });
    })
    .catch(error => console.error('Unable to get items.', error));

    const Salon = 'https://localhost:44390/api/Salon';
    fetch(Salon)
    .then(response => response.json())
    .then(data => {  
        data.forEach(d => {
            var option = document.createElement("option");
            option.text = d.nombreSalon;
            option.value = d.nombreSalon;
            var select = document.querySelector(".selectSalon");
            select.appendChild(option);
        });
    })
    .catch(error => console.error('Unable to get items.', error));

    const Semestre = 'https://localhost:44390/api/Semestre';
    fetch(Semestre)
    .then(response => response.json())
    .then(data => {  
        data.forEach(d => {
            var option = document.createElement("option");
            option.text = d.descripcion;
            option.value = d.descripcion;
            var select = document.querySelector(".selectSemestre");
            select.appendChild(option);
        });
    })
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