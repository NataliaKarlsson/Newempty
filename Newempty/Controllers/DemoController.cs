using Microsoft.AspNetCore.Mvc;

namespace Newempty.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PreferdLanguageCookie()
        {
            string? lang = Request.Cookies["PrefLang"];
            if (!string.IsNullOrEmpty(lang))
            {
                ViewBag.Lang = lang;
            }
            return View();
        }
        public IActionResult SetLanguageCookie(string lang)
        {



            if (!string.IsNullOrWhiteSpace(lang))
            {
                //Add cookie to Response object
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddMinutes(1);
                Response.Cookies.Append("PrefLang", lang, option);
            }
            return RedirectToAction(nameof(PreferdLanguageCookie));
        }


    }
}
