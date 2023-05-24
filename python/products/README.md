# Products API Unit Tests

The products API retunrs records from a DynamoDB Table. In the prior excercises you used pytest to validate your code is working as expected. In this excercise, you will use CodeWhisperer to generate unit tests. 

The API has a single unit test that returns one row of data. Create a second test that returns multiple rows. Note that the unit test, like all the previous unit tests, mocks get_product. This ensures that we are not querying the the real table during the test. 

## Hint

CodeWhisperer is great at generating unit tests. For example:

```
# Patch get_products and test lambda_handler returns multiple records
```
