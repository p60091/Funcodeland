# Make a two-player Rock-Paper-Scissors game. (Hint: Ask for player plays (using input), compare them, print out a message of congratulations to the winner, and ask if the players want to start a new game)


newGame = True;
conditions = [["rr", "pp", "ss"], ["rs", "pr", "sp"], ["sr", "rp", "ps"], []]
verdict = ["Draw. Everyone Loses!", "Player A, you're Winner!", "Player B, you're winner!", "Please only use r, p, or s"]
while( newGame ):
	hand = input( "Player A (r/p/s): " ).lower()[0] + input( "Player B (r/p/s): " ).lower()[0]
	for i in range(4):
		if i < 3 and hand in conditions[i]: 
			break;
	print( verdict[i] )
	if input( "Play again (y/n)?" ) != 'y': 
		newGame=False
	
	

		