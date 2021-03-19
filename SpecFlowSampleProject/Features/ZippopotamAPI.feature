Feature: ZippopotamAPI
	API for getting details of zipcode

@mytag
Scenario Outline: Get details of zipcode
	Given a user is connected to the zippotam url	
	When the user enters a <Zipcode1> 	
	Then the <placename> , <state> details are returned
	Examples: 
	         | Zipcode1 | placename     | state |
	         | 90210    | Beverly Hills |	CA	|
	         | 77494    | Katy          |   TX  |		 
	          