import json 
from unittest import TestCase
from deals_api import lambda_handler;

class TryTesting(TestCase):
    def test_function_returns_json(self):
        event = {
            "httpMethod": "GET",
            "headers": {
                "Accept": "application/json",
            }
        }
        response = lambda_handler(event, context=None)
        body = response['body']
        self.assertEqual(response['statusCode'], 200)
        self.assertEqual(response['headers']['content-type'], 'application/json')
        self.assertEqual(body[0], '[')        

    def test_function_returns_xml(self):
        event = {
            "httpMethod": "GET",
            "headers": {
                "Accept": "application/xml",
            }
        }
        response = lambda_handler(event, context=None)
        body = response['body']
        self.assertEqual(response['statusCode'], 200)
        self.assertEqual(response['headers']['content-type'], 'application/xml')
        self.assertEqual(body[0], '<')
