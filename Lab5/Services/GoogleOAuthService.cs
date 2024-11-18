using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Lab5.Data.Entities;
using Microsoft.AspNetCore.WebUtilities;

namespace Lab5.Services;

// Сервіс для роботи з Google OAuth
public class GoogleOAuthService
{
    private static string ClientId = Config.ClientId; // Ідентифікатор клієнта (Google API)
    private static string ClientSecret = Config.ClientSecret; // Секретний ключ клієнта (Google API)

    // Генерація URL для запиту авторизації OAuth
    public static string GenerateOAuthRequestUrl(string redirectUrl, string scope, string codeChallenge)
    {
        var endPoint = "https://accounts.google.com/o/oauth2/v2/auth"; // Точка доступу Google OAuth
        var qParams = new Dictionary<string, string>()
        {
            {"client_id", ClientId}, // Ідентифікатор клієнта
            {"redirect_uri", redirectUrl}, // URL для повернення після авторизації
            {"response_type", "code"}, // Тип відповіді - код авторизації
            {"scope", scope}, // Дозволи, які запитуються у користувача
            {"code_challenge", codeChallenge}, // Значення виклику для PKCE
            {"code_challenge_method", "S256"}, // Метод хешування для PKCE
            {"access_type", "offline"} // Доступ для роботи в офлайн-режимі
        };

        return QueryHelpers.AddQueryString(endPoint, qParams); // Формування URL з параметрами
    }

    // Отримання токена доступу за кодом авторизації
    public static async Task<OAuthToken> GetTokenByCode(string code, string codeVerifier, string redirectUrl)
    {
        var tokenEndpoint = "https://oauth2.googleapis.com/token"; // Точка доступу для отримання токена
        var qParams = new Dictionary<string, string>
        {
            { "client_id", ClientId }, // Ідентифікатор клієнта
            { "client_secret", ClientSecret }, // Секрет клієнта
            { "code", code }, // Код авторизації
            { "code_verifier", codeVerifier}, // Версіфікатор коду для PKCE
            {"grant_type", "authorization_code"}, // Тип операції
            {"redirect_uri", redirectUrl} // URL для повернення
        };

        var client = new HttpClient();
        var content = new FormUrlEncodedContent(qParams); // Параметри запиту у форматі `application/x-www-form-urlencoded`

        var response = await client.PostAsync(tokenEndpoint, content); // Надсилання POST-запиту
        var json = await response.Content.ReadAsStringAsync(); // Зчитування відповіді
        if (!response.IsSuccessStatusCode) // Перевірка статусу відповіді
        {
            throw new HttpRequestException(json); // Викидаємо виняток у разі помилки
        }

        var result = JsonSerializer.Deserialize<OAuthToken>(json); // Десеріалізація відповіді у модель `OAuthToken`
        return result;
    }

    // Оновлення токена доступу за допомогою refresh-токена
    public static async Task<OAuthToken> RefreshToken(string refreshToken)
    {
        var refreshEndpoint = "https://oauth2.googleapis.com/token"; // Точка доступу для оновлення токена
        var queryParams = new Dictionary<string, string>()
        {
            { "client_id", ClientId }, // Ідентифікатор клієнта
            { "client_secret", ClientSecret }, // Секрет клієнта
            { "grant_type", "refresh_token" }, // Тип операції - оновлення токена
            { "refresh_token", refreshToken } // Refresh-токен
        };

        var client = new HttpClient();
        var content = new FormUrlEncodedContent(queryParams);

        var response = await client.PostAsync(refreshEndpoint, content); // Надсилання POST-запиту
        var json = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(json); // Викидаємо виняток у разі помилки
        }

        var result = JsonSerializer.Deserialize<OAuthToken>(json); // Десеріалізація відповіді у модель `OAuthToken`
        return result;
    }

    // Отримання Google ID користувача за токеном доступу
    public static async Task<string> GetGoogleId(string token)
    {
        var client = new HttpClient();
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get, // Метод GET
            RequestUri = new Uri("https://www.googleapis.com/oauth2/v1/userinfo?alt=json"), // URL для отримання даних користувача
            Headers = {
                { HttpRequestHeader.Authorization.ToString(), "Bearer " + token }, // Авторизація за токеном
                { HttpRequestHeader.Accept.ToString(), "application/json" } // Очікуваний формат відповіді
            }
        };

        var response = await client.SendAsync(httpRequestMessage); // Надсилання запиту
        var json = await response.Content.ReadAsStringAsync(); // Зчитування відповіді
        var authUser = JsonSerializer.Deserialize<User>(json); // Десеріалізація відповіді у модель `User`
        return authUser.GoogleId; // Повертаємо Google ID
    }
}
