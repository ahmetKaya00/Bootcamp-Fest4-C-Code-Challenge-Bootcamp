using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers;

public class BootcampController : Controller
{

    public IActionResult Index()
    {

        var bootcamp = new Bootcamp();

        bootcamp.Id = 1;
        bootcamp.Title = ".Net Core Bootcamp";
        bootcamp.Description = ".Net Core Bootcampi bugün başladı";
        bootcamp.Image = "1.png";

        return View(bootcamp);
    }

    public IActionResult List()
    {

        var bootcamps = new List<Bootcamp>(){
            new Bootcamp(){Id = 1, Title = ".Net Core Bootcamp", Description = "Güzel bir bootcamp", Image = "1.png"},
            new Bootcamp(){Id = 2, Title = "Game Bootcamp", Description = "Güzel bir bootcamp", Image = "2.png"},
            new Bootcamp(){Id = 3, Title = "Frouned Bootcamp", Description = "Güzel bir bootcamp", Image = "3.png"},
        };
        return View(bootcamps);
    }

}