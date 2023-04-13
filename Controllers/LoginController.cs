using GBC_Bids_Group_6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace assigment1.Controllers
{
    public class LoginController : Controller
	{
        private ItemContext _itemContext { get; set; }

        public LoginController(ItemContext ctx)
        {
            _itemContext = ctx;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
		public ActionResult Test(string username, string password)
		{
			if (string.IsNullOrEmpty(username))
			{
				ViewBag.EmptyUsernameErrorMessage = "Please enter a valid username";
				return View("Login");
			}

            if (string.IsNullOrEmpty(password))
            {
                ViewBag.EmptyPasswordErrorMessage = "Please enter a valid password";
                return View("Login");
            }

            var attemptedUsername = username;
            var attemptedPassword = password;

            var user = _itemContext.Users.FirstOrDefault(u => u.username == attemptedUsername);
            if (user != null) { }

            int count = 0;

            if (user != null) {
                if (user.password == attemptedPassword)
                {
                    count++;
                }
            }


            if (count > 0) 
            {
                ViewData["Username"] = username;
                ViewBag.AccountID = user.id;
                ViewBag.usern = username;
                return View("LoginSuccess");
            }

            else
            {
                ViewBag.InvalidLoginErrorMessage = "Invalid username or password";
                return View("Login");
            }
		}



	}
}
