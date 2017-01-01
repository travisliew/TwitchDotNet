# TwitchDotNet
A .NETCore (UWP) C# Library for Twitch API v5.

## Getting Started

Follow these instructions to get started with TwitchDotNet

### Prerequisites

- Visual Studio (2015 or 2017 RC)
- SDKs and libraries: .NET Native, Windows 10 SDK 10.0.14393.0 or later. Easiest way is to install VS2017 RC and select "Universal Windows Platform development" option when installing
- A Twitch Client-Id, see: https://blog.twitch.tv/client-id-required-for-kraken-api-calls-afbb8e95f843
- Clone this repo to local
- External Nuget dependencies: Newtonsoft.Json

#### Add a reference to project

Build the project and add a reference to the `TwitchDotNet.dll` (locaed in `../bin/<platform (e.g. x86)>/<config (e.g. Debug)>/dll`, or add the project  to your existing solution (via right-clicking your solution in Visual Studio and selecting Add -> Existing Project -> `/path/to/local/repo/TwitchDotNet.csproj`)

### Usage

Clone the repository and open the solution in Visual Studio. 

For <i>unauthenticated</i> Twitch requests:

```
string baseUrl = "https://api.twitch.tv";
string clientId = "<Your-Twitch-Client-Id>";

// Init an unauthenticated client with base url and client id
var client = new TwitchClient(baseUrl, clientId);

// Search for games
var result = await client.SearchGames("Dota");
JObject response_object = JObject.Parse(result?.ToString()); // Parse to JObject
var found_game_list = JsonConvert.DeserializeObject<List<object>>(response_object["games"]?.ToString(); // Parse to list of game objects (refer to Twitch docs for returned JSON)

// Get streams summary
result = await client.GetStreamsSummary();
response_object = JObject.Parse(result?.ToString()); // Parse to JObject
```

For <i>authenticated</i> Twitch requests:

```
string baseUrl = "https://api.twitch.tv";
string clientId = "<Your-Twitch-Client-Id>";
string redirectUri = "<Your-Twitch-Redirect-Uri>";
string scopes = "<Your-Twitch-Scopes>";

// First get an oauth_token for Twitch authentication
string oauth_token = await Oauth2Broker.Authenticate(baseUrl, clientId, redirectUri, scopes);

// Init an authenticated client with base url, client id and an oauth_token
var client = new TwitchClientAuthenticated(baseUrl, clientId, oauth_token);

// Do stuff with Twitch authenticated APIs:

// Get my channel info
var result = await client.GetChannel(); // Uses oauth_token to know my user
JObject response_object = JObject.Parse(result?.ToString()); // Parse to JObject
string displayName = response_object["display_name"]?.ToString(); // Get object by key (display_name) (refer to Twitch docs for returned JSON)

// Follow a channel
// Convert twitch user ids to twitch ids
string myId = client.GetIdByName("my username");
string targetId = client.GetIdByName("target username");
result = await client.FollowChannel(myId, targetId);

// Start my channel commercial
result = await client.StartChannelCommercial(channelId);
```

For more information, please refer to links below:
- [Twitch API v5 Documentation](https://dev.twitch.tv/docs/)
- Authentication: [OAuth2Broker class](TwitchDotNet/Helpers/OAuth2Broker.cs) and [Twitch Authentication docs](https://dev.twitch.tv/docs/v5/guides/authentication/).

## Running the tests

To run tests locaed in test project `TwitchDotNet.Tests`, simply add a Resource file called `Resources.resw` to the root folder of `TwitchDotNet.Tests` with the following values:

`Resources.resw`:

Name | Value | Comment
--- | --- | ---
AUTH_REDIRECT_URI | `<Your-Twitch-Redirect-Uri>` | Twitch Authentication Redirect Uri
AUTH_SCOPES | `<Your-Twitch-Scopes>` | Twitch Authentication Scopes
CLIENT_ID | `<Your-Twitch-Client-Id>` | Client Id
OAUTH_TOKEN | `<Your-Twitch-OAuth-Token>` | Twitch OAuthToken
TWITCH_API_BASE_URL | https://api.twitch.tv | Base Twitch API Url

The test project will use these values to initialise the `TwitchClient(s)` and perform the tests.

<b>Note: OAuth token is manually specified at this stage -- get it from `Fiddler`, `Wireshark` when making using `OAuth2Broker` or directly from browser using the `Inspector` and passing in the auth url manually.</b>

## Nuget

Coming soon
