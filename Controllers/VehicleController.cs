using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleLease.Models;

namespace VehicleLease.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewBag.Drivers = new SelectList(_context.Drivers, "DriverId", "DriverName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Add(Vehicle);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Vehicle);
        }
        
    }
}
