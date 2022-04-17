using KisiTakipMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiTakipMvc.Controllers
{
    public class KisiController : Controller
    {
        public IActionResult Index()
        {
            //KisiViewModel model = new KisiViewModel() { Id = 1, Name = "ibrahim", Surname = "Yazıcı" };
            List<KisiViewModel> model = new List<KisiViewModel>();
            model.Add(new KisiViewModel() { Id = 1, Name = "İbrahim", Surname = "Yazıcı" });
            model.Add(new KisiViewModel() { Id = 2, Name = "Cem", Surname = "Akdemir" });
            model.Add(new KisiViewModel() { Id = 3, Name = "Elif", Surname = "Müftioğlu" });
            return View(model);
        }
    }
}
