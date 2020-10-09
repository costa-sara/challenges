# Kenbi Challenges 2020

For this challenge you will need to authenticate to our OAuth2 server and create an API and a client application.
Both are expected to be created using .Net Core 3.1.
We estimate that this challenge will need 15-20h to be completed.
We will evaluate your project organization, coding style and completeness.

If you are having problems understanding the challenge or implementing any part of it, feel free to contact us.

When you have a solution that you feel confortable with, create a PR for this repo with your solution under 2020.10 > <YOUR_USERNAME>.

## Objective
Implement a solution that provides both a frontend and backend.

The frontend should allow the user to authenticate in our OAuth2 server and present a screen where the user can execute the encryption of the returned data and send it back to the api, which then should store the encrypted data on the database.

## Authentication

* Our server for you to get your auth token is https://squirtle.challenges.kenbi.systems/.

## Database

* We will provide you privately the connection string to a Postgres database that you can write to from your API.
* This database contains a table Challenge with the columns 'Input', 'Output', 'Username', 'CreatedAt' that you must be able to write to.

## API

* Your API must be configured to be protected by our OAuth2 server. For that purpose we will provide you privately the secret that you must use in your API configuration.
* You must implement a GET action for any given controller that returns the string "**alive**". This action must be unsecured.
* You must implement a GET action for any given controller that returns the string "**unencrypted_value**". This action must be secured.
* You must implement a POST action for any given controller that receives a processed string and saves it to the database via the means you consider necessary. This action must be secured.

## Client App

* Your client app must be able to login a user and call on demand your API endpoints to perform the actions described.
* These are the scopes we expect you to need to use our OAuth2 server: "_openid_", "_profile_", "_offline_access_", "_testAPI_".
* After login you must call your GET endpoint to retrieve the string from your API.
* Then you must create an SHA256 hash of that string and POST it to your API.
