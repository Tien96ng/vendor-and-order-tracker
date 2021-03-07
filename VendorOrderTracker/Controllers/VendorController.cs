using Microsoft.AspNetCore.Mvc;

namespace VendorOrderTracker.Controllers
{
    public class VendorController : Controller
    {
        [HttpGet("/vendor")]
        public ActionResult Index()
        {
            return View();
        }
    }
}