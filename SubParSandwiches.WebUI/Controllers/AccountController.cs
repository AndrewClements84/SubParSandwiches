﻿using Microsoft.AspNetCore.Mvc;
using SubParSandwiches.Entities;
using SubParSandwiches.Services.Interfaces;
using SubParSandwiches.WebUI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SubParSandwiches.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationService _authService;
        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _authService.AuthenticateUser(model.Email, model.Password);
                if (user != null)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "User" });
                    }
                }
            }
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                bool result = _authService.CreateUser(user, model.Password);
                if (result)
                {
                    RedirectToAction("Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _authService.SignOut();
            return RedirectToAction("LogOutComplete");
        }

        public IActionResult LogOutComplete()
        {
            return View();
        }

        public IActionResult Unuthorised()
        {
            return View();
        }
    }
}
