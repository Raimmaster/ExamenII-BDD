﻿Feature: Examen
	As a professor
	I want my students to implemente these scenarios
	So that they can pass the class

Scenario: Look for products with less than 10 total Qty that needs backorder 
	Given I have the follwing products
	      | Code | Name | Description |
	      | 1    | A    | an A        |
	      | 2    | B    | a B         |
	      | 3    | C    | a C         |

	And I have the following inventory transactions
	    | ProductCode | Qty | TransactionType |
	    | 1           | 10  | In              |
		| 1           | 20  | In              |
		| 1           | 25  | Out             |
		| 2           | 100 | In              |
		| 2           | 20  | Out             |
		| 3           | 10  | In              |
		| 3           | 30  | In              |

	When we check which products needs backorder 
	Then the following products will appear that needs back order
		 | Code | Name | Description |
	     | 1    | A    | an A        |

Scenario: Order an array of employees 
	Given I have the following employees
	      | Code | Name | 
	      | 1    | C    | 
	      | 2    | A    |
	      | 3    | B    |
	When we QUICKSORT by name
	Then the list should be like this
		| Code | Name |  
	    | 2    | A    |
	    | 3    | B    |
		| 1    | C   |

Scenario:Filter transactions by type In
	Given I have the following inventory transaction
	    | ProductCode | Qty | TransactionType |
	    | 1           | 10  | In              |
		| 1           | 20  | In              |
		| 1           | 25  | Out             |
		| 2           | 100 | In              |
		| 2           | 20  | Out             |
		| 3           | 10  | In              |
		| 3           | 30  | In              |
	When filter by transacion type 'In'
	Then the transactions should look like
		| ProductCode | Qty | TransactionType |
	    | 1           | 10  | In              |
		| 1           | 20  | In              |
		| 2           | 100 | In              |
		| 3           | 10  | In              |
		| 3           | 30  | In              |

Scenario:Getting max/min values of binary tree
	Given I have the following tree nodes
	    | NodeId | Value | Left | Right |
	    | 1      | 100   | 2    | 3     |
		| 2      | 200   | 4    | 5     |
		| 3      | 11    | 6    | 7     |
		| 4      | 10    | 0    | 0     |
		| 5      | 340   | 0    | 0     |
		| 6      | 44    | 8    | 0     |
		| 7      | 52    | 0    | 0     |
		| 8      | 1     | 0    | 0     |

	   
	When get tree stats is called
	Then max value should be 340 and min value should be 1
