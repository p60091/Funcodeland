# Generate a random number between 1 and 9 (including 1 and 9). Ask the user to guess the number, then tell them whether they guessed too low, too high, or exactly right. (Hint: remember to use the user input lessons from the very first exercise)
import random

value = random.randint(1,9)
user_value = int(input( "Pick a value (1-9): " ))
if value == user_value: print( "Just Right" )
elif value > user_value: print( "Too Low" )
else: print( "Too High" )