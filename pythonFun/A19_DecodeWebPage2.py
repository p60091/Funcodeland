# Using the requests and BeautifulSoup Python libraries, print to the screen the full text of the article on this website: http://www.vanityfair.com/society/2014/06/monica-lewinsky-humiliation-culture.
import requests
from bs4 import BeautifulSoup
import textwrap
import shutil

url = 'http://www.vanityfair.com/society/2014/06/monica-lewinsky-humiliation-culture'
soup = BeautifulSoup(requests.get(url).text, 'html.parser')
(width, height) = shutil.get_terminal_size()

# print ( soup.encode('ascii') )

#with open("A19_output.html", "w") as fout:
#    fout.write(str(soup.encode('ascii')))

sections = soup.find_all('section')
line_count = 0
for section in sections:
	#print ( section['class'] )
	if section['class'] == ['content-section']:
		paragraphs = section.find_all('p')
		for p in paragraphs:

			lines = textwrap.wrap(p.get_text(), width)
			print('\n   ', end="")
			line_count += 1;
			for line in lines:
				if line_count >= height-1: 
					input("...")
					line_count = 0;
				print(line.replace(u"\u2018", "'").replace(u"\u2019", "'").replace(u"\u201D", "\"").replace(u"\u201C", "\"").replace(u"\u2026", "...").replace(u"\u2014", "-"))
				line_count += 1;
	
