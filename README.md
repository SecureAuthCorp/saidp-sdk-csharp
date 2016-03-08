# saidp-sdk-csharp
C# SDK for SecureAuth IdP API

## Usage:
```csharp
// Setup the configuration object with your
// SecureAuth API ID, API Key, and URL
Configuration saApiConfig = new Configuration()
{
    AppId = "af1b351845ec47968b27debd9cd4ce53",
    AppKey = "101db0347fdf71dab63cd965b8782ff6ba0f8f1c91e8cf52f970d1267e0fb453",
    SecureAuthRealmUrl = "https://company.secureauth.com/SecureAuth1/"
};

// Instantiate a service object. Passing in the configuration.
SecureAuthService saService = new SecureAuthService(saApiConfig);

// Instantiate a request object for sending 
// one-time passcodes via SMS.
SmsOtpRequest request = new SmsOtpRequest
{
    UserId = "userId",
    FactorId = "Phone1"
};

// Execute the request. Storing results into
// a response object.
SendOtpResponse response = saService.Authenticate.SendSmsOtp(request);

```

