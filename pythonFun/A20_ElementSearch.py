# Write a function that takes an ordered list of numbers (a list where the elements are in order from smallest to largest) and another number. The function decides whether or not the given number is inside the list and returns (then prints) an appropriate boolean.
import math

list = [5, 7, 9, 23, 54, 76, 78, 88, 90, 103, 130, 140, 150, 200]

def binarySearch( list, query ):
	if len(list) == 1:
		if list[0] == query:
			return True;
		return False;

	split = math.ceil(len(list)/2)
	if query > list[split-1]: 
		return binarySearch( list[split:], query )
	else:
		return binarySearch( list[:split], query )
	
for i in range(200):
	if binarySearch(list, i):
		print( str(i) )