class Persona{
    
    constructor(nombre, apellido, edad){
        this.nombre = nombre
        this.apellido = apellido
        this.edad = edad

    }

}

function saludar(){
    alert("Hola que pasa!");
}

function alertConDatos(){
    let nombre = document.getElementById("userName").value;
    let apellido = document.getElementById("userLastName").value;
    let edad = document.getElementById("userEdad").value;
    let persona = new Persona(nombre, apellido, edad);
    alert("Hola, soy: " + persona.nombre + " mi apellido: " + persona.apellido + " y mi edad es " + persona.edad)
}

