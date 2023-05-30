import boto3

# Create SES client
ses = boto3.client('ses')

#function to verify email address