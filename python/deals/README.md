# User API Validation

The deals API allows users to get a list of current promotions. The API is working but it only returns results in JSON. A new customer has requested that we support XML. Your challenge is it add support for XML response. If the user requests XML, the function should return XML. Otherwise, it should return JSON.

## Sample Message

A properly formatted response, looks like this:

```
<deals>
    <deal>'
        <url>URL</url>
        <name>NAME</name>
        <description>DESCRIPTION</description>
        <price>PRICE</price>
        <currency>CURRENCY</currency>
    </deal>
</deals>
```

## Hints 

### Conversion Function 

The JSON response is in the code. Therefore, CodeWhisperer has a lot of information and should be able to easily generate a function to convert from JSON to XML. For example: 

```
# Function to convert deals form json to xml
```

### Requested Type

The requested content type is sent in the `Accepts` header. For this workshop, it will include either `application/json` or `application/xml`. For example:

```
event['headers']['Accept'] == 'application/xml'
```

### Response Type

The validation logic will check the content type of the response in addition to the response body. Don't forget to set the response type. For example:

```
return {
    'statusCode': 200,
    'headers': {'content-type': 'application/xml'},
    'body': CONVERTED_XML
}
```
