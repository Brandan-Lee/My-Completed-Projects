import requests

print("Type quit if you would like to exit")
while True:
    user_input = input("Which pokemon's data would you like? ")
    user_input = user_input.lower()

    if user_input == "quit":
        break

    url = f"https://pokeapi.co/api/v2/pokemon/{user_input}"

    req = requests.get(url)

    if req.status_code == 200:
        pokemon = req.json()

        print(f"Name is:\t\t{pokemon['name']}")
        print("Abilities")

        for i, ability in enumerate(pokemon['abilities']):
            print(f"{i + 1}:\t\t{ability['ability']['name']}")
    else:
        print("This pokemon does not exist")

