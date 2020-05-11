using MyLibrary.Models;
using System.Linq;
using System.Web.Mvc;

namespace MyLibrary.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login       
        public ActionResult Index()
        {
            Session["OturumID"] = null;
            return View();
            
        }

        MyLibraryDatabaseEntities db = new MyLibraryDatabaseEntities();
        [HttpPost]

        public ActionResult Index(LoginModel girisYap)
        {
            if (db.UsersAccounts.Where(x => x.user_account_name == girisYap.KADI).FirstOrDefault() != null)
            {
                if (db.UsersAccounts.Where(x => x.user_account_name == girisYap.KADI).FirstOrDefault().user_passwd == girisYap.PASS)
                {
                    var sessionAl = db.UsersAccounts.Where(x => x.user_account_name == girisYap.KADI).FirstOrDefault().user_id;
                    Session["OturumID"] = sessionAl;
                    
                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                }
                else
                {
                    ViewBag.d ="Hata";
                    return View();
                }

            }
            ViewBag.d = "Hata";
            return View();

        }

    }
}    