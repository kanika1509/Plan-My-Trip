using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanMyTripDAL;


namespace PlanMyTripApp.Controllers.MVCControllers
{
    public class HotelController : Controller
    {
        PMTRepository pmtRepo = new PMTRepository();
        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult ViewHotels()
        {
            
                        List<Hotel> hotels = pmtRepo.ViewHotels();
                        List<Models.HotelClass> Hotlist = new List<Models.HotelClass>();
                        foreach (var h in hotels)
                        {
                            Models.HotelClass Hot = new Models.HotelClass();
                            Hot.HoteId = h.HoteId;
                            Hot.City = h.City;
                            Hot.HotelName = h.HotelName;
                            Hot.Address = h.Address;
                            Hot.Description = h.Description;
                            Hot.Phone = h.Phone;
                            Hot.Email = h.Email;
                            Hot.AvrRoomRent = h.AvrRoomRent;
                            Hot.Rating = h.Rating;

                            Hotlist.Add(Hot);

                        }
                        return View(Hotlist);
                    }
                    public ActionResult AddHotel()
                    {
                        return View();
                    }
                    [HttpPost]
                    public ActionResult AddHotel(Models.HotelClass hotel)
                    {
                        Hotel dalhotel = new Hotel();
                        dalhotel.HoteId = hotel.HoteId;
                        dalhotel.HotelName = hotel.HotelName;
                        dalhotel.Address = hotel.Address;
                        dalhotel.City = hotel.City;
                        dalhotel.Description = hotel.Description;
                        dalhotel.AvrRoomRent = hotel.AvrRoomRent;
                        dalhotel.Phone = hotel.Phone;
                        dalhotel.Rating = hotel.Rating;
                        dalhotel.Email = hotel.Email;

                        bool status = pmtRepo.AddHotel(dalhotel);
                        if (status)
                        {
                            ViewBag.msg = "success";

                        }
                        else
                        {
                            ViewBag.errmsg = "failed";
                        }
                        return RedirectToAction("ViewHotels","Hotel");

                    }
                    public ActionResult DeleteHotel(Models.HotelClass hotels)
                    {
                        return View(hotels);
                    }

                    // POST: Customer/Delete/5
                    [HttpPost]
                    public ActionResult DeleteHotel(int id, Models.HotelClass hotels)
                    {
                        try
            {
               // bool status = pmtRepo.DeleteRoomdetails(id);
               bool status=pmtRepo.DeleteHotel(id);

                            
                            if (status)
                            {
                               // Session.Clear();
                                return RedirectToAction("ViewHotels", "Hotel");

                            }
                            else
                            {
                                return Content("Error while Deleting Hotel information");

                            }

                            // TODO: Add delete logic here


                        }
                        catch
                        {
                            return View("Error");
                        }
                    }
                    public ActionResult ViewHotel(int id)
                    {


                        Hotel DalHot = pmtRepo.GetHotelById(id);
                        Models.HotelClass modHot = new Models.HotelClass();
                        modHot.HoteId = DalHot.HoteId;
                        modHot.HotelName = DalHot.HotelName;
                        modHot.Email = DalHot.Email;
                        modHot.AvrRoomRent = DalHot.AvrRoomRent;
                        modHot.Rating = DalHot.Rating;
                        modHot.City = DalHot.City;
                        modHot.Address = DalHot.Address;
                        modHot.Phone = DalHot.Phone;
                        modHot.Description = DalHot.Description;

                        return View(modHot);

                    }
                    //  GET: Hotel/Details/5
                    public ActionResult Details(int id)
                    {
                        return View();
                    }

                    // GET: Hotel/Create
                    public ActionResult Create()
                    {
                        return View();
                    }

                    // POST: Hotel/Create
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

                    // GET: Hotel/Edit/5
                    public ActionResult EditHotel(Models.HotelClass hotels)
                    {
                        return View(hotels);
                    }

                    // POST: Hotel/Edit/5
                    [HttpPost]
                    public ActionResult EditHotel(int id, Models.HotelClass hotels)
                    {
                        try
                        {

                            Hotel dalHotel = new Hotel();
                            dalHotel.HoteId = id;
                            dalHotel.HotelName = hotels.HotelName;
                            dalHotel.Description = hotels.Description;
                            dalHotel.AvrRoomRent = hotels.AvrRoomRent;
                            dalHotel.City = hotels.City;
                            dalHotel.Address = hotels.Address;
                            dalHotel.Phone = hotels.Phone;
                            dalHotel.Rating = hotels.Rating;
                            dalHotel.Email = hotels.Email;
                            dalHotel.Rating = hotels.Rating;
                            bool status = pmtRepo.UpdateHotel(dalHotel);
                            if (status)
                            {
                                ViewBag.msg = "Edit successfull";
                                 return RedirectToAction("ViewHotels", "Hotel");
                }
                            else
                            {
                                ViewBag.errmsg = "Edit unsuccessfull";
                            }
                            return View();

                        }
                        catch
                        {
                            return View("Error");
                        }
                    }
        }
    }
