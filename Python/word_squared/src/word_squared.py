# Write your solution here
#create squared function
def squared(characters, size):
    #create count variable
    i = 0
    #create empty row
    row = ""
    #loop while i < size * size
    while i < size * size:
        if i > 0 and i % size == 0:
            print(row)
            row = ""
        row += characters[i % len(characters)]
        i += 1
    print(row)
 # Testing the function
if __name__ == "__main__":
    squared("ab",3)
    print()
    squared("aybabtu", 5)

#examples of output
#aba
# bab
# aba

#aybab
# tuayb
# abtua
# ybabt
# uayba