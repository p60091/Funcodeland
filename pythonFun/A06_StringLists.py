# Ask the user for a string and print out whether this string is a palindrome or not. (A palindrome is a string that reads the same forwards and backwards.)

#
name = input( "Enter String: " )
palin = True
for i in range(int(len(name)/2)):
	if name[i] != name[len(name)-1-i]:
		palin = False
		break;
print(palin)

#
print (name[:int(len(name)/2)]);
print (name[:len(name)-1-int(len(name)/2):-1]);