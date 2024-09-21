using Microsoft.AspNetCore.Mvc;

namespace TrueVote.Web.Controllers;

public sealed class SurveysController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        
    }
}