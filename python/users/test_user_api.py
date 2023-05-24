import json 
from unittest import TestCase
import user_api 
from unittest.mock import patch, MagicMock


class TestUserApi(TestCase):
    
    @patch('user_api.send_message_to_sqs', MagicMock)
    def test_valid_message_should_return_200(self):
        body = {
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

        event = {
            "body": json.dumps(body)
        }

        response = user_api.lambda_handler(event, context=None)
        self.assertEqual(response['statusCode'], 200)

    @patch('user_api.send_message_to_sqs', MagicMock)
    def test_invalid_email_should_return_400(self):
        body = {
            "username": "john",
            "email": "NOT_A_VALID_EMAIL_ADDRESS",
            "first_name": "John",
            "last_name": "Doe",
            "age": 30,
            "city": "New York",
            "state": "NY",
            "zip": "10001",
            "country": "USA"
        }

        event = {
            "body": json.dumps(body)
        }

        response = user_api.lambda_handler(event, context=None)
        self.assertEqual(response['statusCode'], 400)

    @patch('user_api.send_message_to_sqs', MagicMock)
    def test_invalid_zip_should_return_400(self):
        body = {
            "username": "john",
            "email": "john@example.com",
            "first_name": "John",
            "last_name": "Doe",
            "age": 30,
            "city": "New York",
            "state": "NY",
            "zip": "NOT_A_VALID_ZIPCODE",
            "country": "USA"
        }

        event = {
            "body": json.dumps(body)
        }

        response = user_api.lambda_handler(event, context=None)
        self.assertEqual(response['statusCode'], 400)

    @patch('user_api.send_message_to_sqs', MagicMock)
    def test_missing_fields_should_return_400(self):
        body = {
            "username": "john",
            "email": "john@example.com",
            "age": 30,
            "city": "New York",
            "state": "NY",
            "zip": "10001",
            "country": "USA"
        }

        event = {
            "body": json.dumps(body)
        }

        response = user_api.lambda_handler(event, context=None)
        self.assertEqual(response['statusCode'], 400)