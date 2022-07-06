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
        private readonly IService service;


        public HomeController(IService service)          
        {                                                   

            this.service = service;
        }

        public IActionResult Index()
        {

            return View(service.GetAllPosts());

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
            return View(service.ShowSelectedPost(id));
        }

        public IActionResult AskQuestion()
        {
            return View();
        }
        public IActionResult SearchTag()
        {
            return View();
        }
        public IActionResult SearchUser()
        {
            return View();
        }
    }
}