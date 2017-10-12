# Given two .txt files that have lists of numbers in them, find the numbers that are overlapping. One .txt file has a list of all prime numbers under 1000, and the other .txt file has a list of happy numbers up to 1000.

list1 = []
list2 = []
with open("primenumbers.txt", "r") as fin:
	for num in fin.read().split("\n"):
		list1.append( int(num) )
with open("happynumbers.txt", "r") as fin:
	for num in fin.read().split("\n"):
		list2.append( int(num) )
			
list3 = [item for item in list1 if item in list2]
print( "found " + str(len(list3)) + " overlaps" )
print( list3 )

print([ int(line) for line in open('happynumbers.txt','r') for sec in open('primenumbers.txt','r') if int(line) == int(sec) ])