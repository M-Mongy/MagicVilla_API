using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public IActionResult login()
        {
            loginRequesetDTO obj = new();
            return View (obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(loginRequesetDTO obj)
        {
            APIResponse response = await _auth.loginAsync<APIResponse>(obj);
            if (response != null && response.IsSuccess)
            {
                LoginResponseDTO login = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));

                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(login.Token);


                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                var nameClaim = jwt.Claims.FirstOrDefault(u => u.Type == "name");
                if (nameClaim != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Name, nameClaim.Value));
                }

                var roleClaim = jwt.Claims.FirstOrDefault(u => u.Type == "role");
                if (roleClaim != null)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, roleClaim.Value));
                }
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString(SD.SessionToken, login.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.ErrorMessages.FirstOrDefault());
                return View(obj);
            
            }
           
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationRequestDTO obj)
        {
            APIResponse result = await _auth.registerAsync<APIResponse>(obj);
            if (result != null && result.IsSuccess)
            {
                return RedirectToAction("Login");
            }

            // Add this to show the error message to the user!
            if (result?.ErrorMessages?.Count > 0)
            {
                ModelState.AddModelError("CustomError", result.ErrorMessages.FirstOrDefault());
            }

            // Pass the model back to the view to keep the user's input
            return View(obj);
        } 

        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(SD.SessionToken, "");
            return RedirectToAction("Index", "Home");

        }
        public IActionResult AccessDenied()
        {
            return View();

        }

    }
}
