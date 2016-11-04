# SACustomAPI
A .NET MVC WebApp using SecureAuth APIs

## Requirements
* IIS Webserver
* .NET Framework 4.5.2
* SecureAuth IdP with API configured ( [https://docs.secureauth.com/x/LwZPAg](https://docs.secureauth.com/x/LwZPAg))


## Configuration
Simply build the application in release mode and add to your IIS web server as a virtual application.
Edit the following items in the web.config:
* ` <add key="AppId" value="" />` - Insert your AppId provided by the SecureAuth API
* `<add key="AppKey" value="" />` - Insert your AppKey provided by the SecureAuth API
* `<add key="SecureAuthUrl" value="" />` - Insert the hostname and realm of the SecureAuth realm configured for API