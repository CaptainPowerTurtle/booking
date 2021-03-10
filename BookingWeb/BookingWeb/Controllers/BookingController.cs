using BookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingWeb.Service;

namespace BookingWeb.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(Tour tour)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                await BookingService.SendMessage(tour);
                message = tour.Email;
            }
            else
            {
                message = "Failed to create the product. Please try again";
            }
            return Ok();
        }
    }
}
