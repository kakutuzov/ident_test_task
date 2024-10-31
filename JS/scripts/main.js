const link = document.querySelector("#target");
const jokeDiv = document.querySelector("#joke");

const jokesAPI = "https://official-joke-api.appspot.com/random_joke";

link.addEventListener("click", linkClicked);
link.addEventListener("mouseover", linkHover);

function linkClicked(event){
    event.preventDefault();
    fetch(jokesAPI.toString())
        .then((response) => response.json())
        .then((json) => setJokeText(json));
}

function linkHover(event){
    link.setAttribute("title", getHref());
}

function getHref(){
    return link.getAttribute("href");
}

async function setJokeText(joke) {
    jokeDiv.innerText = joke.setup + " " + joke.punchline;
}