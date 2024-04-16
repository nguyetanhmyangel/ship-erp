using Microsoft.AspNetCore.Mvc;

namespace ShipErp.Api.Controllers.AdminApi;
public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
