# TechStart_Test
Solution to TechStart Test

Before executing this solution, you must need to change the "ConnectionString" value on appsettings.json to connect to your local sql server. This changes need to be made on TechStart_Test project.

Also, it's important to indicate that for getting the authorization token, you need to generate it first on "http://localhost:5000/Token", for example:

	Sample request:
	```html
	POST https://localhost:5000/Token HTTP/1.1
	Host: localhost:5000
	Content-Type: application/x-www-form-urlencoded; charset=UTF-8


	grant_type=password&username=demo&password=demo
	```

	HTTP Response

	```json
    {
      "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1",
      "expires_in": 900,
      "refresh_token": "590b0810a9ad4ec194344375ee1cece9"
    }
	```
After generating token, include it as a header param for the methods to consume.

	Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1l
	
Available Urls:

	http://localhost:5000/api/PharmacyInventory/1/1 (PHARMACY INVENTORY - PUT)
	http://localhost:5000/api/PharmacyInventory (PHARMACY INVENTORY - POST)
	http://localhost:5000/api/PharmacyInventory/1/1 (PHARMACY INVENTORY - DELETE)
	http://localhost:5000/api/PharmacyInventory/1/1 (PHARMACY INVENTORY - GET)
	http://localhost:5000/api/Item (ITEM - POST)
	http://localhost:5000/api/Item/1 (ITEM - GET)
	http://localhost:5000/api/Item/1 (ITEM - PUT)
