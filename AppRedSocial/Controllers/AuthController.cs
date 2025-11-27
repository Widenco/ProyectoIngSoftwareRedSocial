using Microsoft.AspNetCore.Mvc;
using AppRedSocial.Models;

namespace AppRedSocial.Controllers
{
    public class AuthController : Controller
    {
        // Vista de Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            return RedirectToAction("Index", "Home");
        }


        // Vista de REGISTER 
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

           

            
            return RedirectToAction("Login");
        }


        // Vista de FORGOT PASSWORD 
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

           

            TempData["Info"] =
                "Si existe una cuenta asociada a ese correo, recibirás instrucciones para restablecer la contraseña.";

            return RedirectToAction("ForgotPasswordConfirmation");
        }


        // Vista de CONFIRMATION 
        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
    }
}
