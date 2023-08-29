#Pre-task
#Please write a program which asks the user for integer numbers. The program should keep asking for numbers
#  until the user types in zero.

#Part 1: Count
#After reading in the numbers the program should print out how many numbers were typed in. The zero at the end
#  should not be included in the count.

#You will need a new variable here to keep track of the numbers typed in.

#Part 2: Sum
#The program should also print out the sum of all the numbers typed in. The zero at the end should not be
#  included in the calculation.

#Part 3: Mean
#The program should also print out the mean of the numbers. The zero at the end should not be included in the
#  calculation. You may assume the user will always type in at least one valid non-zero number.

# Write your solution here
#create interface
print("Please type in integer numbers. Type in 0 to finish.")
#variables needed
count = 0
sum = 0
mean = 0
pos = 0
negatives = 0 
#iterate through loop until user enters 0
while True:
    number = int(input("Number: "))

    if number == 0:
        break
    else:
        count += 1
        sum += number
        mean = sum / count

    #check to see if number is positive or not
    if number > 0:
        pos += 1
    else:
        negatives += 1
    
print("... the program asks for numbers")
print(f"Numbers typed in {count}")
print(f"The sum of the numbers is {sum}")
print(f"The mean of the numbers is {mean}")
print(f"Positive numbers {pos}")
print(f"Negative numbers {negatives}")

#examples of output
#1
#Please type in integer numbers. Type in 0 to finish.
#Number: 5
# Number: 22
# Number: 9
# Number: -2
# Number: 0
# ... the program asks for numbers
# Numbers typed in 4

#2
#Please type in integer numbers. Type in 0 to finish.
# Number: 5
# Number: 22
# Number: 9
# Number: -2
# Number: 0
# ... the program asks for numbers
# Numbers typed in 4
# The sum of the numbers is 34

#3
#Please type in integer numbers. Type in 0 to finish.
# Number: 5
# Number: 22
# Number: 9 
# Number: -2
# Number: 0
# ... the program asks for numbers
# Numbers typed in 4
# The sum of the numbers is 34
# The mean of the numbers is 8.5

#4
#Please type in integer numbers. Type in 0 to finish.
# Number: 5
# Number: 22
# Number: 9
# Number: -2
# Number: 0
# ... the program asks for numbers
# Numbers typed in 4
# The sum of the numbers is 34
# The mean of the numbers is 8.5
# Positive numbers 3
# Negative numbers 1