import requests

# Data to be sent
data = {
    'username': 'username',
    'password': 'password'
}

# Configuration for the request
headers = {
    'Content-Type': 'application/x-www-form-urlencoded'
}
url = 'http://api.example.com/login'

# Making the API request
response = requests.post(url, data=data, headers=headers)

# Handling the response
if response.status_code == 200:
    print(response.json())
else:
    print(f"Error with status code: {response.status_code}")
