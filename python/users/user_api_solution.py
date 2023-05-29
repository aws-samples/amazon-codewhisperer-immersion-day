import os
import boto3
import json

QUEUE_URL = os.getenv("QUEUE_URL", default="test")
sqs = boto3.client('sqs')


# Function to send the message to SQS
def send_message_to_sqs(body):
    print('Sending message to SQS')
    sqs.send_message(
        QueueUrl=QUEUE_URL,
        MessageBody=json.dumps(body)
    )


# Function to validate an email address using a regular expression
def validate_email(email):
    import re
    if re.match(r"[^@]+@[^@]+\.[^@]+", email):
        return True
    return False


# Function to test if a string contains a five digit US zip code
def validate_zip(zip):
    if len(zip) == 5:
        if zip.isdigit():
            return True
    return False


# Function to test if required fields are present in the message body
def validate_required_fields(body):
    if 'username' in body and 'email' in body and 'first_name' in body and 'last_name' in body and 'age' in body and 'city' in body and 'state' in body and 'zip' in body and 'country' in body:
        return True
    return False


# Lambda function to publish user to a queue
def lambda_handler(event, context):
    print(event)
    try:
        body = json.loads(event['body'])
    
        # Validate email
        if not validate_email(body['email']):
            return {'statusCode': 400}
    
        # Validate zip
        if not validate_zip(body['zip']):
            return {'statusCode': 400}
        
        # Validate required fields
        if not validate_required_fields(body):
            return {'statusCode': 400}
    
        send_message_to_sqs(body)
        return {'statusCode': 200}
    except Exception as e:
        print(e)
        return {'statusCode': 500}