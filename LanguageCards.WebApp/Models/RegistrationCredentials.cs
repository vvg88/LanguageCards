using LanguageCards.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LanguageCards.WebApp.Models
{
    public class RegistrationCredentials : SignInCredentials
    {
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        
        public static explicit operator User(RegistrationCredentials credentials)
        {
            return new User()
            {
                FirstName = credentials.FirstName,
                LastName = credentials.LastName,
                Email = credentials.Email,
                UserName = credentials.Email,
            };
        }
    }
}