Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@mytag
Scenario: Create
	Given I have a new customer with this details
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber   |
		| Ebrahim   | Naderloo | 15/01/1991  | 0123456789  | e.naderloo@gmail.com | 0000-0000-0000-0000 |
	When create the customer
	Then the customer should be saved in the database

Scenario: Update
	Given there is a customer
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber   |
		| Ebrahim   | Naderloo | 15/01/1991  | 0123456789  | e.naderloo@gmail.com | 0000-0000-0000-0000 |
	When update the customer's firstname to "Ebi"
	Then customer's name should be updated in the database

Scenario: Delete
	Given there is a customer
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber   |
		| Ebrahim   | Naderloo | 15/01/1991  | 0123456789  | e.naderloo@gmail.com | 0000-0000-0000-0000 |
	When delete the customer
	Then the customer should be deleted from the database

Scenario: ListAll
	Given there is a list of customers
	When get all
	Then return list of customers