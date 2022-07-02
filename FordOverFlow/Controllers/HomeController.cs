using FordOverFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using FordOverFlow.BusinessLayer;
using FordOverFlow.DataAccessLayer;
using FordOverFlow.CommonEntities;
using FordOverFlow.DataAccessLayer.UnitOfWork;

namespace FordOverFlow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly DatabaseContext _db;


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public HomeController(DatabaseContext db, ILogger<HomeController> _logger, IUnitOfWork _unitOfWork)           //Db burda olmamalı. Katmanlı mimari uygun değil. Çözüm bul
        {                                                   
            _db = db;
            logger = _logger;
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {

            //Test t = new Test();
            //List<User> user = new List<User>();
            //user = t.GetUsers(_db).ToList();
            //return View(user);

            List<User> user = new List<User>();               
            user = unitOfWork.UserRepository.GetAll().ToList();
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