using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanMyTripDAL;
using PlanMyTripWebAPI;
using System.Net.Http;
     

namespace PlanMyTripApp.Controllers.MVCControllers
{
    public class SearchController : Controller
    {
        PMTRepository repo = new PMTRepository();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchHotels()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchHotels(FormCollection collection)
        {
            string city = collection["City"];
            IEnumerable<PlanMyTripWebAPI.Models.SearchHotelsView> apiHotelslist = null;
            List<Models.HotelModel> mvcHotel = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:62921/api/");//this is the base address
                var response = httpClient.GetAsync("Search/" + city);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var responseData = result.Content.ReadAsAsync<List<PlanMyTripWebAPI.Models.SearchHotelsView>>();
                    apiHotelslist = responseData.Result;// this list is of api type class now we need to convert it again to mode
                    mvcHotel = new List<Models.HotelModel>();
                    foreach (PlanMyTripWebAPI.Models.SearchHotelsView hotel in apiHotelslist)
                    {
                        //translate api category to mvc category object
                        Models.HotelModel cat = new Models.HotelModel();
                        cat.HotelName = hotel.HotelName;
                        cat.Address = hotel.Address;
                        cat.Description = hotel.Description;
                        cat.RoomName = hotel.RoomName;
                        cat.RoomType = hotel.RoomType;
                        cat.PerDayRate = hotel.PerDayRate;

                        mvcHotel.Add(cat);
                    }
                }
                else
                {
                    // pass an empty category if service status is 404
                    apiHotelslist = Enumerable.Empty<PlanMyTripWebAPI.Models.SearchHotelsView>();
                }
                return View("SearchHotelsResult", mvcHotel);
            }
        }

        
        [HttpGet]
        public ActionResult SearchFlights()
        {
            List<Airport> DALList = repo.GetAllAirports();
            List<Models.AirportModel> MVCList = new List<Models.AirportModel>();
            Models.FlightSchedule FlightSchedule = new Models.FlightSchedule();
            foreach (var ar in DALList)
            {
                Models.AirportModel ob = new Models.AirportModel();
                ob.AirportCode = ar.AirportCode;
                ob.AirportName = ar.AirportName;
                // ob.Description = ar.Description;
                MVCList.Add(ob);

            }
            FlightSchedule.Airports = MVCList;
            return View(FlightSchedule);
        }

        [HttpPost]
        public ActionResult SearchFlights(FormCollection collection)
        {
            string origin = collection["Origin"];
            string destination = collection["Destination"];
            string date1 = collection["Date"].Trim();
            //DateTime date = Convert.ToDateTime();
            //string[] str = date.Split('/');
            IEnumerable<PlanMyTripWebAPI.Models.SearchFlightsView> apiFlightlist = null;
            List<Models.SearchFlightsModel> mvcFlight = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:62921/api/");//this is the base address
                var response = httpClient.GetAsync("Search/" + origin.Trim() + "/" + destination.Trim() + "/" + date1.Trim());
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var responseData = result.Content.ReadAsAsync<List<PlanMyTripWebAPI.Models.SearchFlightsView>>();
                    apiFlightlist = responseData.Result;// this list is of api type class now we need to convert it again to mode
                    mvcFlight = new List<Models.SearchFlightsModel>();
                    foreach (PlanMyTripWebAPI.Models.SearchFlightsView flight in apiFlightlist)
                    {
                        //translate api category to mvc category object
                        Models.SearchFlightsModel cat = new Models.SearchFlightsModel();
                        cat.FlightNumber = flight.FlightNumber;
                        cat.FlightName = flight.FlightName;
                        cat.DepartureTime = flight.DepartureTime;
                        cat.ArrivalTime = flight.ArrivalTime;
                        cat.NoOfSeatsAvailable = flight.NoOfSeatsAvailable;
                        cat.FlightType = flight.FlightType;
                        mvcFlight.Add(cat);
                    }
                }
                else
                {
                    // pass an empty category if service status is 404
                    apiFlightlist = Enumerable.Empty<PlanMyTripWebAPI.Models.SearchFlightsView>();
                }
                return View("SearchFlightsResult", mvcFlight);
            }
        }

    }
}