using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Project.Models.UserModel user) {
            if (ModelState.IsValid) {
                if (IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ModelState.AddModelError("", "Login is incorrect");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Project.Models.UserModel user) {
            if (ModelState.IsValid)
            {
                using (var db = new MainDbEntities()) {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encryptedPass = crypto.Compute(user.Password);
                    var sysuser = db.SystemUsers.Create();
                    sysuser.email = user.Email;
                    sysuser.username = user.Username;
                    sysuser.password = encryptedPass;
                    sysuser.password = crypto.Salt;
                    sysuser.Id = Guid.NewGuid();
                    db.SystemUsers.Add(sysuser);
                    db.SaveChanges

                }
            }
            return View();
        }

        public ActionResult logout() {
            return View();
        }

        private bool IsValid(String email, String password) {
            var crypto = new SimpleCrypto.PBKDF2();
            bool isValid = false;
            using (var db = new MainDbEntities()) {
                var user = db.SystemUsers.FirstOrDefault(u => u.email == email);
                if (user != null) {
                    if (user.password == crypto.Compute(password, user.passwordsalt)) {
                        isValid = true;
                    }
                }
            }
                
                return isValid;
        }

    }
}