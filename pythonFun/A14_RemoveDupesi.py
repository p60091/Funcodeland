# Write a program (function!) that takes a list and returns a new list that contains all the elements of the first list minus all the duplicates.

# this is dont by default when converting to set
a = [1, 1, 2, 3, 5, 8, 89, 13, 21, 34, 55, 55, 2, 89, 3]
print( set(a) ) 
print( [a[i] for i in range(len(a)) if a[i] not in a[:i]] ) 