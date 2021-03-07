using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Controllers
{
    public class VendorController : Controller
    {
        [HttpGet("/vendor")]
        public ActionResult Index()
        {
          List<Vendor> allVendors = Vendor.GetAll();
          return View(allVendors);
        }
    }
}