# write a program that returns a list that contains only the elements that are common between the lists (without duplicates). Make sure your program works on two lists of different sizes.
a = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
b = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
c = [];
print('a =', a)
print('b =',b)

#
for i in a:
	for j in b:
		if i==j:
			c.append(i)
			break
print (c)

# correct
c=[]
cal=len(a)
for count in range(cal):
	if a[count] in b and a[count] not in c:
		c.append(a[count])
print(c)

# incorrect
print([i for i in a if i in b])

# correct
print("In common elements = {} ".format(set(a)&set(b)))