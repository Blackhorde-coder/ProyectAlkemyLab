using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlkemyLabs.Controllers;
using AlkemyLabs.Models;

namespace AlkemyLabs.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (User) HttpContext.Current.Session["User"];
            if (oUser == null)
            {
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Login");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true && oUser.Administrator == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/User/Index");
                }
                else if (filterContext.Controller is LoginController == true && oUser.Administrator == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");

                }


            }

            base.OnActionExecuting(filterContext);
        }
    }
}