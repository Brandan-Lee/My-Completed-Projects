const cName = document.getElementById("name");
const height = document.getElementById("height");
const mass = document.getElementById("mass");
const hairColor = document.getElementById("hair-color");
const skinColor = document.getElementById("skin-color");
const eyeColor = document.getElementById("eye-color");
const birthYear = document.getElementById("birth-year");
const gender = document.getElementById("gender");

const button = document.querySelector("#randomize-button");
button.addEventListener("click", (e) => {
    e.preventDefault();  
    const randomNumber = Math.ceil(Math.random() * 83);
    fetch(`https://swapi.dev/api/people/${randomNumber}`)
        .then(response => response.json())
        .then(character => {
           cName.innerHTML = character["name"];
           height.innerHTML = character["height"];
           mass.innerHTML = character["mass"];
           hairColor.innerHTML = character["hair_color"];
           skinColor.innerHTML = character["skin_color"];
           eyeColor.innerHTML = character["eye_color"];
           birthYear.innerHTML = character["birth_year"];
           gender.innerHTML = character["gender"];
        })
})
