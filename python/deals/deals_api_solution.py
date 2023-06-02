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

# Function to convert json to xml
def json_to_xml(json_data):
    xml = '<deals>'
    for deal in json_data:
        xml += '<deal>'
        xml += '<url>' + deal['url'] + '</url>'
        xml += '<name>' + deal['name'] + '</name>'
        xml += '<description>' + deal['description'] + '</description>'
        xml += '<price>' + deal['price'] + '</price>'
        xml += '<currency>' + deal['currency'] + '</currency>'
        xml += '</deal>'
    xml += '</deals>'
    return xml

# Lambda function to insert user into DynamoDB table
def lambda_handler(event, context):
    print(event)
    try:
        #read the Accept header to determine the format of the response
        accept = event['headers']['Accept']

        #if the Accept header is application/xml, convert the deals to xml and return it
        if accept == 'application/xml':
            return {
                'statusCode': 200,
                'body': json_to_xml(deals),
                'headers': {
                    'content-type': 'application/xml'
                }
            }
        
        #if the Accept header is application/json, return the deals as json
        elif accept == 'application/json':
            return {
                'statusCode': 200,
                'body': json.dumps(deals),
                'headers': {
                    'content-type': 'application/json'
                }
            }
    except Exception as e:
        print(e)
        return {'statusCode': 500}