# Ask the user for a number and determine whether the number is prime or not. (For those who have forgotten, a prime number is a number that has no divisors.). You can (and should!) use your answer to Exercise 4 to help you. Take this opportunity to practice using functions, described below.
import sys

def prima( input ):
	for i in range(2,input-1):
		if input % i == 0:
			return False
	return True
		
		
		
print (prima(int(sys.argv[1])))