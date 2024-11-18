using System.ComponentModel.DataAnnotations;

namespace Lab5.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Ім'я користувача обов'язкове.")]
    [MaxLength(50, ErrorMessage = "Ім'я користувача не повинно перевищувати 50 символів.")]
    public string Username { get; set; }

    // Full Name (max 500 characters)
    [Required(ErrorMessage = "ФІО обов'язкове.")]
    [MaxLength(500, ErrorMessage = "ФІО не повинно перевищувати 500 символів.")]
    public string FullName { get; set; }

    // Password validation
    [Required(ErrorMessage = "Пароль обов'язковий.")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Пароль повинен містити від 8 до 16 символів.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+={}\[\]|\\:;,.<>?/`~]).{8,16}$",
        ErrorMessage = "Пароль повинен містити хоча б одну велику літеру, одну цифру та один спеціальний символ.")]
    public string Password { get; set; }

    // Confirm password
    [Required(ErrorMessage = "Підтвердження паролю обов'язкове.")]
    [Compare("Password", ErrorMessage = "Паролі не співпадають.")]
    public string ConfirmPassword { get; set; }

    // Phone (Ukraine format: +380XXXXXXXXX)
    [Required(ErrorMessage = "Телефон обов'язковий.")]
    [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Невірний формат телефону.")]
    public string Phone { get; set; }

    // Email (RFC 822 format)
    [Required(ErrorMessage = "Електронна пошта обов'язкова.")]
    [EmailAddress(ErrorMessage = "Невірний формат електронної адреси.")]
    public string Email { get; set; }
}