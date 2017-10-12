# Use the BeautifulSoup and requests Python packages to print out a list of all the article titles on the New York Times homepage.
import requests
from bs4 import BeautifulSoup

url = 'http://www.nytimes.com'
soup = BeautifulSoup(requests.get(url).text, 'html.parser')
# print ( soup.encode('ascii') )

with open("A17_output.html", "w") as fout:
    fout.write(str(soup.encode('ascii')))

titles = soup.find_all('article')
for title in titles:
    link=title.find('a')
    if link != None:
        print ( link.get_text().encode('utf-8') )
