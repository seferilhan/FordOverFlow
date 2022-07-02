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
        PostManager pm = new PostManager();



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
                   
            return View(pm.GetAllPosts(_db));
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
        public IActionResult SelectedPost(int id)
        {
            return View(pm.SelectPost(_db, id));
        }
    }
}