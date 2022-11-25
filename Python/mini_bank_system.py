from typing import List

valid_age = 18
max_withdraw = 100000

class Person:
    def __init__(self,
                 person_id: int,
                 name: str,
                 age: int,
                 accounts: List['Account']):

        self.person_id = person_id
        self.name = name
        self.age = age
        self.accounts = accounts

    
    def check_integrity(self) -> bool:
        is_valid = False
        if self.age >= valid_age:
            if self.name != "":
                for i in range(len(self.accounts)):
                    if self.accounts[i].owner == self:
                        is_valid = True
        return is_valid


class Account:
    def __init__(self,
                account_id: int,
                password: str,
                balance: int,
                limit: int,
                owner: Person):
        
        self.account_id = account_id
        self.password = password
        self.balance = balance
        self.limit = limit
        self.owner = owner


    def add_balance(self, password: str, amount: int) -> bool:
        is_valid: bool = False

        if password == self.password:
            if self.balance + amount <= self.limit:
                self.balance += amount
                is_valid = True

        return is_valid


    def withdraw_balance(self, password: str, amount: int) -> bool:
        is_valid = False

        if password == self.password:
            if amount <= max_withdraw:
                if self.balance - amount >= 0:
                    self.balance -= amount
                    is_valid = True

        return is_valid


    def set_limit(self, password: str, new_limit: int) -> bool:
        is_valid = False

        if password == self.password:
            self.limit = new_limit
            is_valid = True
        
        return is_valid


    def total_remaining(self) -> int:
        return self.balance


my_person = Person(111, "martin", 19, [])
ucet = Account(155, "heslo123", 10000, 20000, my_person)
my_person.accounts.append(ucet)

print(my_person.check_integrity())
