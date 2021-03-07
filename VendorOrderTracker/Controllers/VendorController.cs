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

      [HttpGet("/vendor/{id}")]
      public ActionResult Show(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Vendor selectedVendor = Vendor.Find(id);
        List<Order> vendorOrders = selectedVendor.Orders;
        model.Add("Vendor", selectedVendor);
        model.Add("Orders", vendorOrders);
        return View(model);
      }

      [HttpPost("/vendor/delete")]
      public ActionResult Delete(int id)
      {
        Vendor.Delete(id);
        return RedirectToAction("Index");
      }
    }
}