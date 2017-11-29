using LanguageCards.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class SignInCredentials
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
