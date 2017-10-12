import pygame

class GNode:
	XCurrent = None
	YCurrent = None
	Radius = None

	XTarget = None
	YTarget = None
	
	def __init__ (self):
		pass
	
	def Update(self):
		pass
		
	def Draw(self, surface):
		pygame.draw.circle( surface, RED, (XCurrent-Radius,YCurrent-XRadius,XCurrent+Radius,YCurrent+XRadius), 0 )