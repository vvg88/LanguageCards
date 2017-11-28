using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections;
using JWT;
using JWT.Serializers;
using JWT.Algorithms;
using Microsoft.Extensions.Options;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LanguageCards.WebApp.Models;
using LanguageCards.Data.Entities;
using LanguageCards.Data.Repositories;
using LanguageCards.Data;

namespace LanguageCards.WebApp.Controllers
{
    /// <summary>
    /// Provides methods for user identity operations
    /// </summary>
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly JWTSettings options;
        private readonly IUsersRepository usersRep;

        public AccountController(UserManager<User> userManager,
                                 SignInManager<User> signInManager,
                                 IOptions<JWTSettings> optionsAccessor,
                                 LanguageCardsContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            options = optionsAccessor.Value;
            usersRep = RepositoryProvider.GetUsersRepository(context);
        }

        /// <summary>
        /// Called on user's sign-in operation
        /// </summary>
        /// <param name="credentials"> Sign-in credentials that include user's e-mail and the password </param>
        /// <returns> The result of operation </returns>
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInCredentials credentials)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(credentials.Email);
                    return new JsonResult(new Dictionary<string, object>
                    {
                        { "access_token", GetAccessToken(credentials.Email) },
                        { "id_token", GetIdToken(user) }
                    });
                }
                return new JsonResult("Unable to sign in") { StatusCode = 401 };
            }
            return Error("Unexpected error");
        }

        /// <summary>
        /// Called on user's registration
        /// </summary>
        /// <param name="credentials"> User's registration credentials that include an e-mail, a password, the first and the second name </param>
        /// <returns> The result of operation </returns>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationCredentials credentials)
        {
            if (ModelState.IsValid)
            {
                var userIdentity = (User)credentials;
                var result = await userManager.CreateAsync(userIdentity, credentials.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(userIdentity, isPersistent: false);
                    return new JsonResult(new Dictionary<string, object>
                    {
                        { "access_token", GetAccessToken(credentials.Email) },
                        { "id_token", GetIdToken(userIdentity) }
                    });
                }
                return Errors(result);
            }
            return Error("Unexpected error");
        }
        
        /// <summary>
        /// Called on user's sign-out
        /// </summary>
        /// <returns> The result of operation </returns>
        // POST: /Account/sign-out
        [HttpPost("sign-out")]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private string GetIdToken(User user)
        {
            var payload = new Dictionary<string, object>
            {
                { "id", user.Id },
                { "sub", user.Email },
                { "email", user.Email },
                { "emailConfirmed", user.EmailConfirmed },
            };
            return GetToken(payload);
        }

        private string GetAccessToken(string Email)
        {
            var payload = new Dictionary<string, object>
            {
                { "sub", Email },
                { "email", Email }
            };
            return GetToken(payload);
        }

        private string GetToken(Dictionary<string, object> payload)
        {
            var secret = options.SecretKey;

            payload.Add("iss", options.Issuer);
            payload.Add("aud", options.Audience);
            payload.Add("nbf", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("iat", ConvertToUnixTimestamp(DateTime.Now));
            payload.Add("exp", ConvertToUnixTimestamp(DateTime.Now.AddDays(7)));
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload, secret);
        }

        private JsonResult Errors(IdentityResult result)
        {
            var items = result.Errors
                .Select(x => x.Description)
                .ToArray();
            return new JsonResult(items) { StatusCode = 400 };
        }

        private JsonResult Error(string message)
        {
            return new JsonResult(message) { StatusCode = 400 };
        }

        private double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}