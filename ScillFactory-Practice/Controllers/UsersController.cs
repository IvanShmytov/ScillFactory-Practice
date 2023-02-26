using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ScillFactory_Practice.Models.Db;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ScillFactory_Practice.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository<User> _repo;

        public UsersController(IRepository<User> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Authenticate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login) ||
              String.IsNullOrEmpty(password))
                throw new ArgumentNullException("Запрос не корректен");

            User user = _repo.GetByLogin(login);
            if (user is null)
                throw new AuthenticationException("Пользователь на найден");

            if (user.Password != password)
                throw new AuthenticationException("Введенный пароль не корректен");
            List<Claim> userClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Login),
                            new Claim(ClaimTypes.Role, user.Role)
                        };

            var identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return View("GetUserByID",user);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetAll();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repo.Get(id);
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.Add(newUser);
            return View(newUser);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _repo.Get(id);
            await _repo.Delete(user);
            return RedirectToAction("Index", "Users");
        }
        [Authorize (Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var article = await _repo.Get(id);
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmUpdating(User user)
        {
            await _repo.Update(user);
            return RedirectToAction("Index", "Users");
        }
    }
}
