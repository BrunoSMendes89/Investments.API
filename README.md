# Investments.Api Documentation

## Overview

**Title:** Investments.Api  
**Version:** 1.0

Investments.Api is a RESTful API designed to manage users, customers, products, and transactions within an investment platform. The API supports operations for creating users, customers, and products, updating product details, managing customer balances, and retrieving transaction information.

## Endpoints

<details>
  <summary>1. Create User</summary>

**URL:** `/createuser`  
**Method:** `POST`  
**Tag:** `Backoffice`

**Request Body:**
- `application/json`
- `text/json`
- `application/*+json`
  
**Schema:** `PostUserRequest`
```json
{
  "userName": "string",
  "email": "string"
}
```
<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `object`
```json
{
  "userId": 0,
  "userName": "string",
  "email": "string",
  "active": true
}
```
</details>

<details>
  <summary>Response (412 Failed Dependency) in case when email already exists.</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `string`
  - `text/json`
```string
This email already exists.
```
**Response Schema:** `object`

</details>

</details>

<details>
  <summary>2. Create Customer</summary>

**URL:** `/createcustomer`  
**Method:** `POST`  
**Tag:** `Backoffice`

**Request Body:**
- `application/json`
- `text/json`
- `application/*+json`
  
**Schema:** `PostCustomerRequest`
<table border="1">
  <tr>
    <th>Create Customer Request</th>
  </tr>
  <tr>
    <td>Name</td><td>Name chosed to user</td>
  </tr>
  <tr>
    <td>AccountBalance</td><td>Entry value to open the account.</td>
  </tr>
</table>

```json
{
  "name": "string",
  "accountBalance": 0
}
```
<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `object`
  ```json
  {
  "customerId": 0,
  "name": "string",
  "accountNumber": "string",
  "accountBalance": 0
  }
  ```
</details>

<details>
  <summary>Response (412 Failed Dependency)</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `string`
  - `text/json`
 ```string
   Precondition Failed
 ```

**Response Schema:** `string`

</details>

</details>

<details>
  <summary>3. Create Product</summary>

**URL:** `/createproduct`  
**Method:** `POST`  
**Tag:** `Backoffice`

**Request Body:**

- `application/json`
- `text/json`
- `application/*+json`

**Schema:** `PostProductRequest`
<table border="1">
  <tr>
    <th>Create Product Request</th>
  </tr>
  <tr>
    <td>Name</td><td>Name chosed to Product</td>
  </tr>
  <tr>
    <td>Price</td><td>Entry value of the product.</td>
  </tr>
  <tr>
    <td>productType</td><td>Chose between: <b>1 = Stocks, 2 = REIT, 3 = Treasures, 4 = ETF, 5 = Bitcoin</b>.</td>
  </tr>
</table>

```json
{
  "name": "string",
  "price": 0,
  "productType": 1,
  "dueDate": "2024-07-01T21:15:01.795Z"
}
```
<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `string`
```json
{
  "productId": 0,
  "name": "string",
  "price": 0,
  "quantity": 0,
  "productType": 1,
  "dueDate": "2024-07-01T21:15:01.797Z",
  "active": true
}
```
</details>

<details>
  <summary>Response (412 Failed Dependency)</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `string`
  - `text/json`

**Response Schema:** `string`
```string
   Precondition Failed
 ```
</details>

</details>

<details>
  <summary>4. Update Product</summary>

**URL:** `/product/{productId}`  
**Method:** `PUT`  
**Tag:** `Backoffice`

**Parameters:**
<table border="1">
  <tr>
    <th>Update Product Parameters</th>
  </tr>
  <tr>
    <td>ProductId</td><td>Id of the Product</td>
  </tr>
  <tr>
    <td>Price</td><td>New product price.</td>
  </tr>
  <tr>
    <td>Quantity</td><td>Quantity <b>to be added to the product</b>.</td>
  </tr>
  <tr>
    <td>ProductType</td><td>Chose between: <b>1 = Stocks, 2 = REIT, 3 = Treasures, 4 = ETF, 5 = Bitcoin</b>.</td>
  </tr>
  <tr>
    <td>DueDate</td><td>Due date to product.</td>
  </tr>
</table>

**Note**
- `Every field must be sent or the value will be replaced to null`
<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `string`
```json
{
  "productId": 0,
  "name": "string",
  "price": 0,
  "quantity": 0,
  "productType": 1,
  "dueDate": "2024-07-01T21:29:28.938Z",
  "active": true
}
```
</details>

<details>
  <summary>Response (412 Failed Dependency)</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `string`
```string
  Precondition Failed
```
</details>

</details>

<details>
  <summary>5. Delete Product</summary>

**URL:** `/product/{productId}`  
**Method:** `DELETE`  
**Tag:** `Backoffice`

**Parameters:**

<table border="1">
  <tr>
    <th>Update Product Parameters</th>
  </tr>
  <tr>
    <td>ProductId</td><td>Id of the Product</td>
  </tr>
</table>

<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `unit`
```string
"Deleted. The id is: {id}"
```
</details>

<details>
  <summary>Response (412 Failed Dependency)</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `string`
```string
  Precondition Failed
```

</details>

</details>

<details>
  <summary>6. Send Email</summary>

**URL:** `/email`  
**Method:** `POST`  
**Tag:** `Backoffice`

<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `string`

</details>

<details>
  <summary>Response (500 Internal Server Error)</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `string`
```string
  Precondition Failed
```
</details>

</details>

<details>
  <summary>7. Update Customer Balance</summary>

**URL:** `/balance/{customerId}`  
**Method:** `PUT`  
**Tag:** `Customer`

**Parameters:**
<table border="1">
  <tr>
    <th>Update Customer Amount Parameters</th>
  </tr>
  <tr>
    <td>CustomerId</td><td>Id of the Customer</td>
  </tr>
  <tr>
    <td>TransactionType</td><td>New product price.</td>
  </tr>
  <tr>
    <td>ProductType</td><td>Chose between: <b>0 = Credit, 1 = Debit</b>.</td>
  </tr>
  <tr>
    <td>Amount</td><td>Amount to be credited or debited.</td>
  </tr>
</table>

<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `object`
```json
{
  "customerId": 0,
  "name": "string",
  "accountNumber": "string",
  "accountBalance": 0
}
```
</details>

<details>
  <summary>Response (412 Failed Dependency) in case TransactionType isn't <b>0 = Credit</b> or <b>1 = Debit</b></summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `string`
```string
  Transaction Type not Allowed
```
</details>

</details>

<details>
  <summary>8. Get Transactions</summary>

**URL:** `/transactions/{customerId}`  
**Method:** `GET`  
**Tag:** `Customer`

**Parameters:**
<table border="1">
  <tr>
    <th>Get Customer Transactions</th>
  </tr>
  <tr>
    <td>CustomerId</td><td>Id of the Customer</td>
  </tr>
</table>

<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `Array of Transactions`
```json
[
  {
    "transactionId": 0,
    "date": "2024-07-01T22:00:22.741Z",
    "description": "string",
    "amount": 0,
    "transactionType": 0,
    "customerId": 0,
    "productId": 0
  }
]
```
</details>

<details>
  <summary>Response (412 Failed Dependency)</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `String`
```string
  Precondition Failed
```
</details>

</details>

<details>
  <summary>9. Get Products</summary>

**URL:** `/products`  
**Method:** `GET`  
**Tag:** `Products`

**Parameters:**
`In this endpoint you can choose to get with how many parameters do you want. If you don't choose parameters, it will get the first 15 itens.`
<table border="1">
  <tr>
    <th>Get Products</th>
  </tr>
  <tr>
    <td>Id</td><td>Id of the Product</td>
  </tr>
  <tr>
    <td>Description</td><td>Full or part of Product Name.</td>
  </tr>
  <tr>
    <td>ProductType</td><td>Chose between: <b>1 = Stocks, 2 = REIT, 3 = Treasures, 4 = ETF, 5 = Bitcoin</b>.</td>
  </tr>
</table>

<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `array of GetProductsResponse`
```json
[
  {
    "productId": 0,
    "name": "string",
    "price": 0,
    "productType": 1,
    "dueDate": "2024-07-01T22:05:06.525Z"
  }
]
```
</details>

<details>
  <summary>Response (412 Failed Dependency)</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `String`
```string
  Precondition Failed
```
</details>

</details>

<details>
  <summary>10. Negotiate Product by Customer</summary>

**URL:** `/products`  
**Method:** `POST`  
**Tag:** `Products`

**Request Body:**
`This endpoint will check the quantity of the product and, based on its price, will debit of his account balance.`
- `application/json`
- `text/json`
- `application/*+json`

**Schema:** `PostProductByCustomerRequest`
<table border="1">
  <tr>
    <th>Get Products</th>
  </tr>
  <tr>
    <td>CustomerId</td><td>Id of the Customer</td>
  </tr>
  <tr>
    <td>ProductId</td><td>Id of the Product</td>
  </tr>
  <tr>
    <td>Quantity</td><td>Negotiated quantity of the product.</td>
  </tr>
  <tr>
    <td>TransactionType</td><td>Chose between: <b>2 = Buy, 3 = Sell</b>.</td>
  </tr>
</table>

```json
{
  "customerId": 0,
  "productId": 0,
  "quantity": 0,
  "transactionType": 0
}
```
<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `string`
```json
{
  "productId": 0,
  "name": "string",
  "price": 0,
  "quantity": 0,
  "productType": 1,
  "dueDate": "2024-07-01T22:21:57.452Z",
  "active": true
}
```
</details>

<details>
  <summary>Response (412 Failed Dependency)</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `string`
```string
  Transaction Type not Allowed
```
</details>

</details>

<details>
  <summary>11. Test Handler</summary>

**URL:** `/TestHandler`  
**Method:** `GET`  
**Tag:** `Test`

**Parameters:**
`Endpoint to test if API is working. No database is necessary`
- `ChooseResponse` (query, integer, int32)

<details>
  <summary>Response (200 OK)</summary>

**Response:**

- `200 OK`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `TestResponse`
```json
{
  "response": "Você escolheu o número 1"
} 
```
</details>

<details>
  <summary>Response (412 Failed Dependency)</summary>

**Response:**

- `412 Failed Dependency`
  - `text/plain`
  - `application/json`
  - `text/json`

**Response Schema:** `TestResponse`

</details>

</details>

## Components

### Schemas

**GetProductsResponse**
```json
{
  "type": "object",
  "properties": {
    "id": {
      "type": "integer",
      "format": "int32"
    },
    "description": {
      "type": "string"
    },
    "productType": {
      "type": "string",
      "enum": [
        "Type1",
        "Type2"
      ]
    }
  }
}
```
**PostUserRequest**
```json
{
  "type": "object",
  "properties": {
    "username": {
      "type": "string"
    },
    "password": {
      "type": "string"
    }
  }
}
```
**PostCustomerRequest**
```json
{
  "type": "object",
  "properties": {
    "name": {
      "type": "string"
    },
    "email": {
      "type": "string"
    }
  }
}
```
**PostProductRequest**
```json
{
  "type": "object",
  "properties": {
    "name": {
      "type": "string"
    },
    "price": {
      "type": "number",
      "format": "double"
    }
  }
}
```
**PostProductByCustomerRequest**
```json
{
  "type": "object",
  "properties": {
    "customerId": {
      "type": "integer",
      "format": "int32"
    },
    "productId": {
      "type": "integer",
      "format": "int32"
    }
  },
  "required": [
    "customerId",
    "productId"
  ]
}
```
**TestResponse**
```json
{
  "type": "object",
  "properties": {
    "message": {
      "type": "string"
    },
    "status": {
      "type": "string"
    }
  },
  "required": [
    "message",
    "status"
  ]
}
```
