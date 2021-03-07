using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorOrderTracker.Models;
using System;

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

      [HttpPost("/vendor/{vendorId}/order")]
      public ActionResult Create(int vendorId, string name, string description, int price)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();

        Vendor selectedVendor = Vendor.Find(vendorId);
        Order newOrder = new Order(name, description, price);
        
        selectedVendor.AddOrder(newOrder);
        List<Order> vendorOrders = selectedVendor.Orders;
        model.Add("Orders", vendorOrders);
        model.Add("Vendor", selectedVendor);
        return View("Show", model);
      }

      [HttpPost("/vendor/{vendorId}/delete_all_orders")]
      public ActionResult DeleteAllOrders(int vendorId)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Vendor selectedVendor = Vendor.Find(vendorId);
        selectedVendor.Orders.Clear();
        List<Order> vendorOrders = selectedVendor.Orders;
        model.Add("Vendor", selectedVendor);
        model.Add("Orders", vendorOrders);
        return View("Show", model);
      }
    }
}