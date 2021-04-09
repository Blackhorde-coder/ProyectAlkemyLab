using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlkemyLabs.Models;


namespace AlkemyLabs.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Enter(String user, String password, bool type)
        {
            try
            {
                using (AlkemyLabEntities db = new AlkemyLabEntities())
                {

                    var lst = from d in db.User
                              where d.oUser == user && d.Password == password && d.Administrator == type && d.Active == true
                              select d;

                    if (lst.Count() > 0)
                    {
                        Session["User"] = lst.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario o contraseña incorrectos");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :-( " + ex.Message);
            }
        }
    }
    
}