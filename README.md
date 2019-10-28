# Coding-Assignment
I use Stack to calculate the total score so that the tim complexity is big O of N.
Assumptions:
As the assignments state, the input represents a single,large group that contains many smaller groups. So any input that does not start with ‘{‘ and end with ‘}’, or is not a single group, is invalid.




Restful API:

The design of this web API following all the RESTful principles:

I designed the web API following the Client/Server pattern and the API is devided into multi-layers
All client-server interaction stateless. Server will not store anything about previous HTTP request client made.
This API have a uniform interface. The API interface for the service that calculates the total score,  are exposed to API consumers and follow religiously.
The API is extensible for multi layers and tiers. The logic is 


I also use DI sing Ninject and Unit test using MS Test
