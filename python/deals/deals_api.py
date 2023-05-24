import boto3
import json
import base64

deals = [
    {
        'url': 'https://example.com/deals/001',
        'name': 'Deal 001',
        'description': 'Deal 001 description',
        'price': '100',
        'currency': 'USD',
    },
    {
        'url': 'https://example.com/deals/002',
        'name': 'Deal 002',
        'description': 'Deal 002 description',
        'price': '200',
        'currency': 'USD'
    },
    {
        'url': 'https://example.com/deals/003',
        'name': 'Deal 003',
        'description': 'Deal 003 description',
        'price': '300',
        'currency': 'USD'
    }
]


# Lambda function to insert user into DynamoDB table
def lambda_handler(event, context):
    print(event)
    try:
        return {
            'statusCode': 200,
            'headers': {'content-type': 'application/json'},
            'body': json.dumps(deals)
        }
    except Exception as e:
        print(e)
        return {'statusCode': 500}