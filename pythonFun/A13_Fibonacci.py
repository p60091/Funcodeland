# Write a program that asks the user how many Fibonnaci numbers to generate and then generates them. Take this opportunity to think about how you can use functions. Make sure to ask the user to enter the number of numbers in the sequence to generate.
import sys

#
def fibon( num ):
	res = [1, 1]
	if num < 2:
		return res[0:num-2]
	num -= 2
	for i in range(num):
		res.append(res[len(res)-1] + res[len(res)-2])		
	return res;
	
print( fibon(int(sys.argv[1])) )

#
def fibo(n):
	if n == 1 or n == 2: return 1
	return fibo(n-1)+fibo(n-2)
	
print (fibo(int(input("How many? "))))