#random
#while loop runs forever and stops when you exit
#input
#print statements and formatting
#comparison operators
#break and continue

import random

print("To Exit the game, type quit")

while True:
    userInput = input("Please choose rock, paper or scissors: ")
    userInput = userInput.lower()

    #check user input
    if userInput == "quit":
        break
    elif userInput != "rock" and userInput != "paper" and userInput != "scissors":
        print("Please enter the correct input")
        continue

    #computer input
    computerResponse = random.choice(["rock", "paper", "scissors"])
    print(f"Computers response: {computerResponse}")

    # game
    if userInput == computerResponse:
        print("You tied")
    elif (userInput == "rock" and computerResponse == "scissors") or (userInput == "paper" and computerResponse == "rock") or (userInput == "scissors" and computerResponse == "paper"):
        print("You win!")
        break
    #computer wins
    else:
        print("You lose. Try again!")
        continue