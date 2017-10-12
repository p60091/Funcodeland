# Time for some fake graphics! Let’s say we want to draw game boards that look like this:

boardDim = []
try: 
	boardDim = [int(i) for i in input("please enter a board size (WxH):").split("x")]
	if len(boardDim) != 2: raise ValueError
except:
	print( "Invalid entry!!!" )
	boardDim = []

if boardDim != []:
# dumb
	for j in range(boardDim[1]):
		lines = 2
		if j == boardDim[1]-1: lines = 3
		for k in range(lines):
			for i in range(boardDim[0]):
				if k % 2 == 0: print(" ---", end="" )
				elif i == boardDim[0]-1: print("|   |", end="" ) 
				else: print("|   ", end="" ) 
			print("")


# smart
	for i in range(boardDim[1]):
		print( ' ---' * boardDim[0] )
		print( '|   ' * boardDim[0] + "|" )
	print( ' ---' * boardDim[0] )