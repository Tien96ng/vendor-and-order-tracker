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
      
      [HttpGet("/vendor/new")]
      public ActionResult New()
      {
        return View();
      }

      [HttpPost("/vendor")]
      public ActionResult Create(string name, string description)
      { 
        Vendor newVendor = new Vendor(name, description);
        return RedirectToAction("Index");
      }

      [HttpPost("/vendor/delete_all")]
      public ActionResult DeleteAll()
      {
        Vendor.ClearAll();
        return RedirectToAction("Index");
      }
    }
}