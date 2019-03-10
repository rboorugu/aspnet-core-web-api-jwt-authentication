this project shows demo of how to use jwt token based authentication using asp net core web api
Login a user with username and password (for demo purposes dummy users created in file /Data/Users are used)
call details below 

Route: /login/authenticate
payload:
{
	"Username": "ljames",
	"Password": "james123$"
}
Above will generate return a jwt token

to get all user details for user above call the protected route /user, just jwt token from above as Bearer Token in Hedaer for authorization to get all user details



