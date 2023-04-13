using GBC_Bids_Group_6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace GBC_Bids_Group_6.Controllers
{
    public class NEWRegistrationController : Controller
    {
        private ItemContext _itemContext { get; set; }

        public NEWRegistrationController(ItemContext ctx) 
        {
            _itemContext = ctx;
        }

        public IActionResult RegistrationView() 
        {
            return View("RegistrationView");
        }

        [HttpPost]
        public ActionResult RegisterUser(string username, string password, string confirmPassword, string email) 
        {
            if (string.IsNullOrEmpty(username))
            {
                ViewBag.EmptyUsernameErrorMessage = "Please enter a valid username";
                return View("RegistrationView");
            }

            if (string.IsNullOrEmpty(password))
            {
                ViewBag.EmptyPasswordErrorMessage = "Please enter a valid password";
                return View("RegistrationView");
            }

            if (password != confirmPassword) 
            {
                ViewBag.PasswordsDontMatchErrorMessage = "Passwords do not match";
                return View("RegistrationView");
            }

            if (string.IsNullOrEmpty(email))
            {
                ViewBag.EmptyEmailErrorMessage = "Please enter a valid email";
                return View("RegistrationView");
            }

            var attemptedUsername = username;
            var attemptedEmail = email;

            bool usernameExists = _itemContext.Users.Any(u => u.username == attemptedUsername);
            bool emailExists = _itemContext.Users.Any(u => u.email == attemptedEmail);

            if (usernameExists) 
            {
                ViewBag.TakenUsernameErrorMessage = "This username is already registered";
                return View("RegistrationView");
            }

            if (emailExists)
            {
                ViewBag.TakenEmailErrorMessage = "This email is already registered";
                return View("RegistrationView");
            }

            User newUser = new User
            {
                username = username,
                password = password,
                email = email,
                userType = "Client",
                verified = true
            };

            _itemContext.Users.Add(newUser);
            _itemContext.SaveChanges();



            return View("RegistrationSuccess");


        }

    }
}
