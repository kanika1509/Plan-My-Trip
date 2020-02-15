using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanMyTripDAL;

namespace PlanMyTripApp.Controllers
{
    public class UserController : Controller
    {
        PMTRepository repo = new PMTRepository();
       
        public ActionResult Index()
        {
            return View();
        }

        // GET: User
        public ActionResult Login()
        {

            return View();
        }

        //post user
        [HttpPost]

        public ActionResult Login(FormCollection collection)
        {
            //it will automatically take the form data
            string name = null;
            string emailid = collection["txtEmail"];
            string password = collection["txtPass"];
            int userId = repo.ValidateUser(emailid, password);

            if (userId != -1 )
            {
                Session["userid"] = userId;
                Session["Email"] = emailid;
                
                name = repo.getUSerName(Convert.ToInt32(Session["UserId"]));
                //repo.getUSerName(User.)
                //  ViewBag.msg ="You have successfully logged in";
                Response.Write("Welcome"+name);
                return RedirectToAction("ViewFlights", "Flight");

            }
            else
            {
                ViewBag.errmsg ="Login failed!!Please Try again";
                return View();
            }
          
        }

       

        //get register
        public ActionResult Register()
        {
            return View();
        }


        // post register
        [HttpPost]
        public ActionResult Register(Models.UsersModel user)
        {
            User daluser = new User();
            daluser.UserId = user.UserId;
            daluser.FirstName = user.FirstName;
            daluser.LastName = user.LastName;
            daluser.Password = user.Password;
            daluser.EmailId = user.EmailId;
            //daluser.RoleId = user.RoleId;
            daluser.UserId = user.UserId;

            bool status = repo.AddUser(daluser);
            if (status)
            {
                ViewBag.msg = "User Registration successfull";
                return RedirectToAction("Login","User");
            }
            else
            {
                ViewBag.msg = "User Registration failed";
            }
            return View();

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }

        
    }
}