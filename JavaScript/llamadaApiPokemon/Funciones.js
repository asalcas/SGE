function pedirDatos(){
    let relojito = document.getElementById("relojito")

var miLlamada = new XMLHttpRequest();
miLlamada.open("GET", "https://pokeapi.co/api/v2/pokemon");
//Definicion estados
miLlamada.onreadystatechange = function () {
    //alert(miLlamada.readyState)
if (miLlamada.readyState < 4) {
    relojito.style.display = "block"
    
//aquí se puede poner una imagen de un reloj o un texto “Cargando”

}else
    if (miLlamada.readyState == 4 && miLlamada.status == 200) {
        var arrayPokemon = JSON.parse(miLlamada.responseText);
        pintarPokemons(arrayPokemon.results)
        relojito.style.display = "none"
        
        
    }
};

miLlamada.send();

}

function pintarPokemons(arrayPokemon){
    let Pokemon = document.getElementById("Pokemon")
    Pokemon.innerHTML = ""
    for (i = 1; i <= 10; i++){
        let li = document.createElement("li"); // Generar por HREF en vez de li
        li.textContent = arrayPokemon[i].name; 
        Pokemon.appendChild(li); 
    }

}

