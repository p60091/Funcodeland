# This week’s exercise is going to be revisiting an old exercise (see Exercise 5), except require the solution in a different way.

a = [1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89]
b = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]


print([a[i] for i in range(len(a)) if a[i] not in a[:i] and a[i] in b])
for i in range(len(a)): print( a[:i] )