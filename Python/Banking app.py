class Bank:
    def __init__(self, starting_amount = 0.00):
        self.balance = starting_amount

    def log_transaction(self, transaction_string):
        with open("Bank_Transaction.txt", "w") as file:
            file.write(f"{transaction_string} \t\t\tBalance: {self.balance}")

    def withdrawal(self, amount):
        try:
            amount = float(amount)
        except ValueError:
            amount = 0

        if self.balance - amount < 0:
            self.log_transaction("Insufficient funds!")
            print(f"Your current account balance is {self.balance}")
        else:
            self.balance = self.balance - amount
            self.log_transaction(f"Withdrew: {amount}")

    def deposit(self, amount):
        try:
            amount = float(amount)
        except ValueError:
            amount = 0
        
        if amount:
            self.balance = self.balance + amount
            self.log_transaction(f"Deposited: {amount}")

account = Bank(100.00)

while True:
    try:
        action = input("What kind of action do you want to take? ")
        action.lower
    except KeyboardInterrupt:
        print("Leaving the ATM")

    if action in ["withdraw", "deposit"]:
        if action == "withdraw":
            amount = input("How much would you like to withdraw? ")
            account.withdrawal(amount)
        if action == "deposit":
            amount = input("How much would you like to deposit? ")
            account.deposit(amount)