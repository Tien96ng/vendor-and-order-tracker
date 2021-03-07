using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Controllers
{
  public class OrderController : Controller
  {
    [HttpGet("/vendor/{vendorId}/order/new")]
    public ActionResult New(int vendorId)
    {
      Vendor selectedVendor = Vendor.Find(vendorId);
      return View(selectedVendor);
    }


  }
}