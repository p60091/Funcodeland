# Use the BeautifulSoup and requests Python packages to print out a list of all the article titles on the New York Times homepage.
import requests
from bs4 import BeautifulSoup
import re

#print(text.replace(u"\ufeff", "").replace(u"\u0153", "").replace('\xc8', "").replace('\xc0', "").replace(u"\u2020", "+").replace(u"\u2022", "*").replace(u"\u2018", "'").replace(u"\u2019", "'").replace(u"\u201D", "\"").replace(u"\u201C", "\"").replace(u"\u2026", "...").replace(u"\u2014", "-"));

regex = r"([bB][a-zA-Z']*)( the| a| of| at| for| The| A| Of| At| For| THE| OF| AT| FOR)* ([tT][a-zA-Z']*)( the| a| of| at| for| The| A| Of| At| For| THE| OF| AT| FOR)* ([vV][a-zA-Z']*)( the| a| of| at| for| The| A| Of| At| For| THE| OF| AT| FOR)* ([sS][a-zA-Z']*)"


def AZParseBand( url ):
	soup = BeautifulSoup(requests.get(url).text, 'html.parser')
	sections = soup.find_all('div')
	for section in sections:
		#print ( section['class'] )
		if section['class'] == ['album']:
			album = section.get_text()
			print(album)
			
AZParseBand( "http://www.azlyrics.com/lyrics/santigold/youllfindaway.html" )			
#res = re.findall(regex, text)
#if res != None:
#	for g in res:
#		print (g)