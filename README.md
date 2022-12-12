<center><img src="https://user-images.githubusercontent.com/1976592/207096842-ddd0305e-10fb-4d68-97e8-b06909958a2c.png" /></center>


### BlazeRPC
The simplest way to customize your rich presense status. This is a console application meaning there is no annoying UI to mess with or take up resources on your PC. Simply run the executable, fill out the config, restart the app. Minimise it into the background. 

Once the config is setup, you don't have to do it again, unless you want to change.

- Add usable buttons
- Custom Pictures
- Custom Text
- Simple Config

### Setup

**NOTE: This app requires you setup an application via the Discord developer portal to work.**

1. Goto the following link and Login: https://discord.com/developers/applications
2. Click on `New Application (top right)`
3. Give your application a name (This will show on the rich pressense as a title)
4. Click on OAuth2 and copy your `Client ID`
5. Click on Rich Pressense.
6. Upload the images you wish to use on your Rich Pressense. You're allowed to have one Large image and one smaller image. Follow the guidelines for uploading these images.
7. Run the BlazeRPC
    - If you haven't setup BlazeRPC before, it should give an error saying a config has been made.
8. The config will be located in your Documents folder and will be named `BlazeRPCConfig.json`
9. Fill out the values in the config. Note that LargeImageName and SmallImageName should be the exact same as the names you gave the images on the developer portal.

**NOTE: You are limited to 2 buttons**

Example Config
```json
{
  "Client_ID": "YOURID",
  "Details": "Staff Member @",
  "State": "The Programmers Hangout",
  "LargeImageName": "tphlogo",
  "SmallImageName": "avatar",
  "LargeImageAlt": "TPH Logo",
  "SmallImageAlt": "My Avatar",
  "Buttons": [
    {
      "Name": "Join The Programmers Hangout",
      "Url": "https://discord.gg/programming"
    },
    {
      "Name": "My Links",
      "Url": "https://links.joelparkinson.me"
    }
  ]
}
```

#### Final Result
![xcGdN9](https://user-images.githubusercontent.com/1976592/207097024-6bad4fa1-43e9-4419-8882-d49f35c064c9.png)



### Contributing

#### Compiling source

- Ensure you have Dotnet6 or later installed.
- Clone the repository

```bash
git clone https://github.com/DraxCodes/BlazeRPC.git
cd BlazeRPC
dotnet build
```
