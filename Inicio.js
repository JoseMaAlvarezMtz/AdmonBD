function login(){
    var usuario = "1666476";
    var contraseña = "1666476*";
    var inputUsuario = document.getElementById("usuario").value;
    var inputPass = document.getElementById("pass").value;
    if (usuario==inputUsuario && contraseña==inputPass){
        location.href="Distribuciones.html"
    }
    else{
        alert("Usuario y/o contraseña invalidos");
    }
}