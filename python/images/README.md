# User API Validation

The image API allows users to upload images to S3. The API is working, but users occasionally upload inappropriate images. Your challenge is to moderate images using Amazon Rekognition. If the message includes an inappropriate or offensive image, the function should return a 400 response code.

## Sample Message

A properly formatted request, looks like this:

```
{
    "file_name": "lamp.jpeg",
    "file_type": "image/jpeg",
    "file_content": BASE64_ENCODED_FILE
}
```

## Hints 

### Moderation API

Amazon Rekognition includes an image moderation API. CodeWhisperer is excellent at writing code to access AWS services. For Example.

```
# Function to moderate image with AWS Rekognition
```

### Confidence

Amazon Rekognition's `DetectModerationLabels` API has an optional parameter that specifies the minimum confidence level for the labels to return. For this Workshop you can use the default 50%.

### Moderation Labels

Amazon Rekognition can detect multiple categories of inappropriate or offensive content. For this workshop, you can assume that if Rekognition identifies any `ModerationLabels` that you should reject the image. For example:

```
if len(response["ModerationLabels"]) == 0: 
    return True
else:
    return False
```