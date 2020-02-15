using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanMyTripDAL;

namespace PlanMyTripApp.Controllers.MVCControllers
{
    public class FlightController : Controller
    {
        PMTRepository repo = new PMTRepository();

        // GET: FlightClass
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewFlights()
        {
            List<Models.Flight> modfl = new List<Models.Flight>();
            List<Flight> flights = repo.viewFlights();
            foreach (var item in flights)
            {
                Models.Flight modflights = new Models.Flight();
                modflights.FlightName = item.FlightName;
                modflights.FlightNumber = item.FlightNumber;
                modflights.NoOfSeatsAvailable = item.NoOfSeatsAvailable;
                modflights.SeatsCapacity = item.SeatsCapacity;
                modflights.FlightType = item.FlightType;
                modfl.Add(modflights);
            }

            return View(modfl);

        }




        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            //Models.FlightClass modfl = new Models.FlightClass();
            //id = Session["FlightNumber"].ToString();
            Flight flights = repo.GetFlight(id);

            Models.Flight modflights = new Models.Flight();

            modflights.FlightName = flights.FlightName;
            modflights.FlightNumber = flights.FlightNumber;
            modflights.NoOfSeatsAvailable = flights.NoOfSeatsAvailable;
            modflights.SeatsCapacity = flights.SeatsCapacity;
            modflights.FlightType = flights.FlightType;

            return View(modflights);
            // return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightClass/Edit/5
        public ActionResult Edit(Models.Flight flight)
        {

            return View(flight);
        }


        [HttpPost]
        public ActionResult Edit(string id, Models.Flight flight)
        {
            try
            {

                // TODO: Add update logic here

                Flight flights = new Flight();

                flights.FlightNumber = id;
                flights.FlightName = flight.FlightName;
                flights.FlightType = flight.FlightType;
                flights.NoOfSeatsAvailable = flight.NoOfSeatsAvailable;
                flights.SeatsCapacity = flight.SeatsCapacity;


                bool status = repo.updateFlightDetails(flights);
                if (status)
                {
                    ViewBag.msg = "Details Updated successfully";
                    return RedirectToAction("ViewFlights", "Flight");

                }
                else
                {
                    ViewBag.errmsg = "Error while updating details";
                }
            }
            catch (Exception)
            {

                return View("Error");
            }
            return View();
        }

        //public ActionResult ConfirmDelete()
        //{

        //    return View("");
        //}



        // GET: FlightClass/Delete/5
        public ActionResult Delete(Models.Flight flight)
        {
            return View(flight);
        }

        // POST: FlightClass/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Models.Flight flight)
        {
            bool status = false;
            try
            {
                status = repo.DeleteFlight(id);
                if (status)
                {
                   // Session.Clear();
                    Response.Write("<script type='text/javascript'>alert('Deleted!!');</script>");
                    //return View();
                }
                else
                {
                    return Content("Error while deleting record");
                }

            }
            catch
            {
                return View("Error");
            }
            return RedirectToAction("ViewFlights","Flight");
        }

        public ActionResult AddFlights()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFlights(Models.Flight flights)
        {
            Flight fl = new Flight();

            fl.FlightNumber = flights.FlightNumber;
            fl.FlightName = flights.FlightName;
            fl.FlightType = flights.FlightType;
            fl.SeatsCapacity = flights.SeatsCapacity;
            fl.NoOfSeatsAvailable = flights.NoOfSeatsAvailable;


            bool status = repo.AddFlights(fl);
            if (status)
            {
                ViewBag.msg = "Registeration successful";
                //return RedirectToAction("abc", "home");
            }
            else
            {
                ViewBag.msg = "Registeration un-successful";

            }
            return RedirectToAction("ViewFlights", "Flight");
            // return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }
    }
}