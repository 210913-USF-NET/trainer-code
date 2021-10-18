function getPokemon() {
    let pokeQuery = document.getElementById("pokeQuery").value;
    let pokeUrl = 'https://pokeapi.co/api/v2/pokemon/' + pokeQuery;

    let xhr = new XMLHttpRequest();

    //ready states:
    //0: uninitialized
    //1: loading(server connection established) the open method has been invoked
    //2: loaded (server received the request) and send method has been called
    //first, method, second Url, third async?
    xhr.open("GET", pokeUrl, true); // this is readystate 1
    xhr.send(); //this is ready state 2

    //ready state 3: interactive (processing request), response body is being received
    //ready state 4: complete (we received the response)
    let pokemon = {}
    xhr.onreadystatechange = function() {
        if(this.readyState == 4)
        {
            //we received a response
            if(this.status > 199 && this.status < 300)
            {
                //and the response is successful
                pokemon = JSON.parse(xhr.responseText);
                console.log(pokemon);

                //find the img tag and set the attribute as the img we got from the response
                let imgTag = document.querySelector('.pokemon > img').setAttribute('src', pokemon.sprites.front_default);

                //find the containing div
                let div = document.querySelector('.pokemon');

                //first, remove all pre-existing caption element
                document.querySelectorAll('.pokemon caption').forEach((el) => el.remove());
                
                //create new caption element
                let captionEl = document.createElement('caption');
                //create a text node with the name
                let pokeNode = document.createTextNode(pokemon.name);
                //append the node to the caption element
                captionEl.appendChild(pokeNode);
                //now append the caption element to the div
                div.appendChild(captionEl);
            }
        }
    }
}