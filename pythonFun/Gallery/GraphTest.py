import networkx as nx
import matplotlib.pyplot as plt
import pygame


class GraphTest:
	display_width = 800
	display_height = 600
	black = (0,0,0)
	white = (255,255,255)
	
	G = None
	gameDisplay = None
	clock = None

	x = (display_width * 0.5)
	y = (display_height * 0.5)
	x_change = 0
	car_speed = 0
	
	posCurrent = None
	posTarget = None
	

	def __init__(self):
		pygame.init()

		self.gameDisplay = pygame.display.set_mode((self.display_width,self.display_height))
		pygame.display.set_caption('Graphy')
		
		self.clock = pygame.time.Clock()
		
		self.G=nx.Graph()
		self.G.add_node("test")
		self.G.add_nodes_from([2,3])
		H=nx.path_graph(10)
		self.G.add_nodes_from(H)
		self.G.add_node(H)
		self.G.add_edge(1,2)
		self.G.add_edge(5,3)
		self.G.add_edge(7,3)
		self.G.add_edge(6,3)
		self.posTarget  = nx.spring_layout(self.G)
		print(self.posTarget)
		for item in self.posTarget:
			if type(item) is int or type(item) is str:
				print(str(item) + " -- " + str(self.posTarget[item]))
		
	def update(self):
		for event in pygame.event.get():
			if event.type == pygame.QUIT:
				#crashed = True
				return True

			############################
			if event.type == pygame.KEYDOWN:
				if event.key == pygame.K_LEFT:
					self.x_change = -5
				elif event.key == pygame.K_RIGHT:
					self.x_change = 5
			if event.type == pygame.KEYUP:
				if event.key == pygame.K_LEFT or event.key == pygame.K_RIGHT:
					self.x_change = 0
			######################

		self.x += self.x_change
		return False
	   
	def draw(self):

		self.gameDisplay.fill(self.white)
			
		#nx.draw_spring(G)
		#plt.show()
		   
		pygame.display.update()
		self.clock.tick(60)

	def kill(self):
		pygame.quit()
		
		
crashed = False	
GT = GraphTest();
while not crashed:
	crashed = GT.update();
	GT.draw();

GT.kill()
quit()	
	
	
