using FordOverFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using FordOverFlow.BusinessLayer;
using FordOverFlow.DataAccessLayer;
using FordOverFlow.CommonEntities;
namespace FordOverFlow.Controllers
{
    public class HomeController : Controller
    {


       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly DatabaseContext _db;
        public HomeController(DatabaseContext db)           //Db burda olmamalı. Katmanlı mimari uygun değil. Çözüm bul
        {                                                   
            _db = db;
        }                                               

        public IActionResult Index()
        {
            Test t = new Test();
            List<User> user = new List<User>();
            user = t.GetUsers(_db).ToList();
            return View(user);

        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}