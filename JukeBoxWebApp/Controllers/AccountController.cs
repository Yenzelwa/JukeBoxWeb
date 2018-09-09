using JukeBox.BO.RequestObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JukeBoxWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(UserRequestLogin model)
        {

            if (model.UserName != null && model.Password != null)
            {


                //Set time loggedOn
                var user = await JukeBox.BLL.Administration.Account.ApiLoginClient(model);

                if (user != null)
                {
                    var usrEnabled = (bool)user.basic.Enabled;
                    if (usrEnabled)
                    {

                        var actionList = (string)System.Web.HttpContext.Current.Session["AccessToken"];

                        if (actionList == null)
                        {
                            System.Web.HttpContext.Current.Session["AccessToken"] = user.AccessToken.Token;
                        }
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        // If we got this far, something failed, redisplay form
                        ViewBag.Error = "User name not active";
                        return View(model);
                    }
                }
                else
                {

                    // If we got this far, something failed, redisplay form
                    ViewBag.Error = "Invalid Username / Password";
                    return View(model);
                }
            }
            else
            {
                // If we got this far, something failed, redisplay form
                ViewBag.Error = "The user name or password provided is incorrect.";
                return View(model);
            }

        }
    }
}

         
        

