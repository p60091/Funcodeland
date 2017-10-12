# Given a .txt file that has a list of a bunch of names, count how many of each name there are in the file, and print out the results to the screen. I have a .txt file for you, if you want to use it!

tally = {}
with open("nameslist.txt", "r") as fin:
	for name in fin.read().split("\n"):
		if name in tally.keys():
			tally[name] += 1;
		else:
			tally[name] = 1;
			
print( tally )