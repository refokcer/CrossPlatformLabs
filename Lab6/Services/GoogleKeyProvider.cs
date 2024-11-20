using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace Lab6.Services;

public class GoogleKeyProvider
{
    /// <summary>
    /// Асинхронно загружает открытые ключи для проверки JWT токенов от Google.
    /// </summary>
    /// <param name="url">URL, по которому находятся открытые ключи Google.</param>
    /// <returns>Список открытых ключей в формате JsonWebKey.</returns>
    public static async Task<IReadOnlyCollection<JsonWebKey>> FetchGoogleKeysAsync(string url)
    {
        using var client = new HttpClient();

        var jsonContent = await client.GetFromJsonAsync<JsonElement>(url);
        if (jsonContent.ValueKind != JsonValueKind.Object)
        {
            throw new InvalidOperationException("Некорректный формат данных при запросе ключей Google.");
        }

        var keysProperty = jsonContent.GetProperty("keys");
        var keyCollection = keysProperty.EnumerateArray()
                                        .Select(jsonKey => new JsonWebKey(jsonKey.GetRawText()))
                                        .ToList();

        return keyCollection.AsReadOnly();
    }
}
