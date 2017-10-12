# Create a program that will play the “cows and bulls” game with the user. The game works like this:
# Randomly generate a 4-digit number. Ask the user to guess a 4-digit number. For every digit that the user guessed correctly in the correct place, they have a “cow”. For every digit the user guessed correctly in the wrong place is a “bull.” Every time the user makes a guess, tell them how many “cows” and “bulls” they have. Once the user guesses the correct number, the game is over. Keep track of the number of guesses the user makes throughout teh game and tell the user at the end.

import random;

def checkOnlyNum(input):
	for i in input:
		if i > '9' or i < '0': return False
	return True

if __name__=="__main__":
	newGame = True
	while newGame:
		answer = [str(random.randint( 0, 9 )) for i in range(4)]
		#print ("Shhhh!, answer is " + "".join(answer) )
		numCows = 0
		while numCows < 4:
			numCows = 0
			numBulls = 0
			guess = input("Enter 4 digit guess: ")
			if len(guess) != 4 or checkOnlyNum(guess) == False:
				print( "Invalid input!! Try again!!")
				continue;
			
			for i in range(4):
				if guess[i] == answer[i]: numCows += 1
				elif guess[i] in answer: numBulls += 1
			
			if numBulls > 0 or numCows < 4:
				print( "You have " + str(numCows) + " cows and " + str(numBulls) + " bulls.")
		
		print ("".join(answer) + " is the correct number")
		if input("Play again (y/n): ") != 'y': newGame = False