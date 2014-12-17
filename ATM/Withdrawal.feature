Feature: Atm allows withdrawal of money 
	In order to withdraw cash I need ATM to dispose banknotes.

  Scenario: Successfull withdrawal
	Given there's 1000 PLN on user's account
	When a user withdraws 700 PLN
	Then ATM disposes 700 PLN 
	And there's 300 PLN left on user's account

  Scenario: Withdraw when not enough money on account
	Given there's 50 PLN on user's account
	When a user withdraws 500 PLN
	Then ATM shows error 'Not enough money on your account'

  Scenario: Withdraw when not enough money in ATM
	Given ATM has 50 PLN
	When a user withdraws 500 PLN
	Then ATM shows error 'Not enough banknotes in ATM'



	