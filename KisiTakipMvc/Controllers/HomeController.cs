using _08_DosyaRepository;
using KisiTakipMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KisiTakipMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IKisiRepository _repository;
        Test _t1;
        IDeneme _d;
        public HomeController(ILogger<HomeController> logger, IKisiRepository repository,  Test t1,IDeneme d)
        {
            _repository = repository;
            _logger = logger;
            _t1 = t1;
            _d = d;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
