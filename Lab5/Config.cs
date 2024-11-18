namespace Lab5;

public class Config
{
    public static string? ClientId;
    public static string? ClientSecret;
    public static void Load(IConfiguration configuration)
    {
        ClientId = configuration.GetSection("google").GetSection("id").Get<string>();
        ClientSecret = configuration.GetSection("google").GetSection("secret").Get<string>();
    }
}