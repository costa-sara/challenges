# Tips

* You can easily find a way to perform a SHA256 hash to a string.
* For your token claims to be named correctly you need to apply the following at the start of `ConfigureServices`.
  
  ```csharp
  JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
  ```

* For your name claim to be mapped correctly to the user identity you must configure it inside `.AddJwtBearer`.
  
  ```csharp
  options.TokenValidationParameters = new TokenValidationParameters
  {
      NameClaimType = "name",
      RoleClaimType = "role",
  };
  ```

* We recommend that your client app uses IdentityModel as a helper to your client for our OAuth2 server.
* There are numerous examples and tutorials on how to connect to an OAuth2 server. You'll easily find github samples of clients and APIs for IdentityServer4.
