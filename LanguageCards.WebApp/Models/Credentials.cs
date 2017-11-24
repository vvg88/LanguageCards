using LanguageCards.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LanguageCards.WebApp.Models
{
    public class Credentials
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        public static explicit operator IdentityUser(Credentials credentials)
        {
            return new IdentityUser()
            {
                Email = credentials.Email,
                UserName = $"{credentials.FirstName}_{credentials.LastName}",
            };
        }

        public static explicit operator User(Credentials credentials)
        {
            return new User()
            {
                FirstName = credentials.FirstName,
                LastName = credentials.LastName,
            };
        }
    }
}