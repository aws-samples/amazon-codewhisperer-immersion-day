# User API Validation

The user API allows you to add a user to the system. The API accepts a new user in JSON format and posts it to SQS for further processing. The API is working, but does not validate. As a result, we occasionally publish bad data to the queue that causes downstream processes to fail. Your challenge is to add code to validate that 1) all required fields are present, 2) the email address is valid, and 3) the zip code is a five-digit number. If the message is malformed, the function should return a 400 response code.

## Sample Message

A properly formated request, looks like this:

```
{
    "username": "john",
    "email": "john@example.com",
    "first_name": "John",
    "last_name": "Doe",
    "age": 30,
    "city": "New York",
    "state": "NY",
    "zip": "10001",
    "country": "USA"
}
```

## Hints 

### Zip Code

Zip codes vary from country to country. This app only supports US addresses which are simply five digits numbers. However, CodeWhisperer knows what a US zip code looks like, so you can just ask it for a function

```
# Function to test if a string contains a five digit US zip code
```

### Eamil Address

Regular Expressions are a great way to validate inputs are properly formatted. The syntax can be very confusing, but CodeWhisperer is great at generating regular expressions. For Example: 

```
# Function to validate an email address using a regular expression
```

### Required fields

CodeWhisperer does not know what fields are in the message because the schema is not present in the source code. Try defining a variable, and then ask CodeWhisperer to create a function. For example: 

```
sample = {
    "username": "john",
    "email": "john@example.com",
    "first_name": "John",
    "last_name": "Doe",
    "age": 30,
    "city": "New York",
    "state": "NY",
    "zip": "10001",
    "country": "USA"
}

# Function to test if required fields are present in the message body
```
