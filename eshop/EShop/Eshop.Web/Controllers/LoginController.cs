using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eshop.IService;

namespace Eshop.Web.Controllers
{
    public class LoginController : Controller
    {
        ILoginService loginService;
        public LoginController(ILoginService iLoginService)
        {
            loginService = iLoginService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {

            try
            {
                loginService.Login(username, password);
                return Content("成功");
            }
            catch (Exception ex)
            {

                return Content("錯誤:" + ex.Message);
            }

        }
    }
}