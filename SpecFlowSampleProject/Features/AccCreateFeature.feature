Feature: Account Creation Feature
	Create an account on website

@mytag
Scenario: Create an account
	Given we are on homepage 
	And we click Sign in
	When we enter email "suparnashal@gmail.com"	and click Create Account button
	Then Create an account page opens