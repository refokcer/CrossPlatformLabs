using System.Net;
using System.Text.Json;
using Lab5.Data.Entities;
using Microsoft.AspNetCore.WebUtilities;

namespace Lab5.Services;

public class GoogleOAuthService
{
    private static string ClientId = Config.ClientId;
    private static string ClientSecret = Config.ClientSecret;
    public static string GenerateOAuthRequestUrl(string redirectUrl, string scope, string codeChallenge)
    {
        var endPoint = "https://accounts.google.com/o/oauth2/v2/auth";
        var qParams = new Dictionary<string, string>()
        {
            {"client_id", ClientId},
            {"redirect_uri", redirectUrl},
            {"response_type", "code"},
            {"scope", scope},
            {"code_challenge", codeChallenge},
            {"code_challenge_method", "S256"},
            {"access_type", "offline"}
        };

        return QueryHelpers.AddQueryString(endPoint, qParams);
    }

    public static async Task<OAuthToken> GetTokenByCode(string code, string codeVerifier, string redirectUrl)
    {
        var tokenEndpoint = "https://oauth2.googleapis.com/token";
        var qParams = new Dictionary<string, string>
        {
            { "client_id", ClientId },
            { "client_secret", ClientSecret },
            { "code", code },
            { "code_verifier", codeVerifier},
            {"grant_type", "authorization_code"},
            {"redirect_uri", redirectUrl}
        };
        var client = new HttpClient();
        var content = new FormUrlEncodedContent(qParams);

        var response = await client.PostAsync(tokenEndpoint, content);
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(json);
        }
        var result = JsonSerializer.Deserialize<OAuthToken>(json);
        return result;
    }

    public static async Task<OAuthToken> RefreshToken(string refreshToken)
    {
        var refreshEndpoint = "https://oauth2.googleapis.com/token";
        var queryParams = new Dictionary<string, string>()
        {
            { "client_id", ClientId },
            { "client_secret", ClientSecret },
            { "grant_type", "refresh_token" },
            { "refresh_token", refreshToken }
        };
        var client = new HttpClient();
        var content = new FormUrlEncodedContent(queryParams);

        var response = await client.PostAsync(refreshEndpoint, content);
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(json);
        }

        var result = JsonSerializer.Deserialize<OAuthToken>(json);
        return result;
    }
    public static async Task<string> GetGoogleId(string token)
    {
        var client = new HttpClient();
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://www.googleapis.com/oauth2/v1/userinfo?alt=json"),
            Headers = {
                { HttpRequestHeader.Authorization.ToString(), "Bearer " + token },
                { HttpRequestHeader.Accept.ToString(), "application/json" }
            }
        };
        var response = await client.SendAsync(httpRequestMessage);
        var json = await response.Content.ReadAsStringAsync();
        var authUser = JsonSerializer.Deserialize<User>(json);
        return authUser.GoogleId;
    }
}