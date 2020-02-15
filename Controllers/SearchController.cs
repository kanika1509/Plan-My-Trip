using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlanMyTripDAL;
using System.Web.Http.Results;

namespace PlanMyTripWebAPI.Controllers
{
    public class SearchController : ApiController
    {

        PMTRepository repo = new PMTRepository();

        //[Route("api/GetHotels/{city}")]
        public JsonResult<List<Models.SearchHotelsView>> GetHotels(string city)
        {
            List<usp_SearchHotels_Result> HotelList = repo.SearchHotels(city);
            List<Models.SearchHotelsView> modHotelList = new List<Models.SearchHotelsView>();
            foreach (usp_SearchHotels_Result f in HotelList)
            {
                Models.SearchHotelsView cat = new Models.SearchHotelsView();
                cat.HotelName = f.HotelName;
                cat.PerDayRate = f.PerDayRate;
                cat.RoomName = f.RoomName;
                cat.RoomType = f.RoomType;
                cat.Description = f.Description;
                cat.Address = f.Address;
                modHotelList.Add(cat);
            }
            var jsonresult = Json(modHotelList);
            return jsonresult;
        }

        public JsonResult<List<Models.SearchFlightsView>> GetFlightInfo(string origin, string dest,DateTime departureTime)
        {
            List<usp_SearchFlights_Result> flightList = repo.SearchFlights(origin,dest,departureTime);
            List<Models.SearchFlightsView> modFlightList = new List<Models.SearchFlightsView>();
            foreach (usp_SearchFlights_Result f in flightList)
            {
                Models.SearchFlightsView cat = new Models.SearchFlightsView();
                cat.FlightNumber = f.FlightNumber;
                cat.FlightName = f.FlightName;
                cat.DepartureTime = f.DepartureTime;
                cat.ArrivalTime = f.ArrivalTime;
                cat.NoOfSeatsAvailable = f.NoOfSeatsAvailable;
                cat.FlightType = f.FlightType;
                modFlightList.Add(cat);
           }
            var jsonresult = Json(modFlightList);
            return jsonresult;
        }
        
    }
}
