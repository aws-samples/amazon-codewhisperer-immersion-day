import os
import boto3
import json
from boto3.dynamodb.conditions import Key

TABLE_NAME = os.getenv("TABLE_NAME", default="products")
ddb = boto3.client('dynamodb')


# Function to query products table 
def get_products():
    table = ddb.scan(
        TableName=TABLE_NAME,
        KeyConditionExpression=Key('id').eq(id),
        AttributesToGet=['id', 'name', 'description']
    )
    return table['Items']


# Lambda function to upload an image to S3
def lambda_handler(event, context):
    try:
        productss = get_products() 
        return {
            'statusCode': 200,
            'body': json.dumps(productss),
        }
    except Exception as e:
        print(e)
        return {'statusCode': 500}
