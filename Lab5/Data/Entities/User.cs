using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Lab5.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Data.Entities;

public class User
{
    public Guid Id { get; private set; }
    [JsonPropertyName("id")]
    public string GoogleId { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public User(string googleId, string username, string fullName, string passwordHash, string phoneNumber, string email)
    {
        GoogleId = googleId;
        Username = username;
        FullName = fullName;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        Email = email;
        Id = Guid.NewGuid();
    }
    public User()
    {

    }

    public static User Create(RegisterModel model, string googleId)
    {
        using var sha256 = SHA256.Create();
        var passwordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
        var passwordHash = Base64UrlTextEncoder.Encode(passwordBytes);
        return new User(googleId, model.Username, model.FullName, passwordHash, model.Phone, model.Email);
    }
}