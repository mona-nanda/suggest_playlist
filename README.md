This is the code for the microservice which returns a curated list of tracks belonging to a specific genre based on the temperature outside for a given location. 
Business rules:
If temperature (celcius) is above 30 degrees, suggest tracks for party
In case temperature is between 15 and 30 degrees, suggest pop music tracks
If it's a bit chilly (between 10 and 14 degrees), suggest rock music tracks
Otherwise, if it's freezing outside, suggests classical music tracks

We have implemented 2 services in here : we are using open weather api as a service and spotify as a service

