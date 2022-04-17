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
        static List<KisiViewModel> kisiler;

        [HttpGet]
        public IActionResult Index()
        {
            if (kisiler == null)
            {
                kisiler = new List<KisiViewModel>();
                kisiler.Add(new KisiViewModel() { Id = 1, Name = "İbrahim", Surname = "Yazıcı" });
                kisiler.Add(new KisiViewModel() { Id = 2, Name = "Cem", Surname = "Akdemir" });
                kisiler.Add(new KisiViewModel() { Id = 3, Name = "Elif", Surname = "Müftüoğlu" });
            }

            //KisiViewModel model = new KisiViewModel() { Id = 1, Name = "ibrahim", Surname = "Yazıcı" };
           
            return View(kisiler);
        }

        public IActionResult Details(int id)
        {
            KisiViewModel model = kisiler.FirstOrDefault(c => c.Id == id);
            return View(model);
        }

        public IActionResult Create(int? id)
        {
            if (id.HasValue)
            {
                KisiViewModel model = kisiler.FirstOrDefault(c => c.Id == id);
                return View(model);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(KisiViewModel kisi)
        {
            int maxId = kisiler.Max(c => c.Id) + 1;
            //KisiViewModel yeniKisi = new KisiViewModel() { Id = maxId, Name = Name, Surname = Surname };
            //  KisiViewModel yeni = new KisiViewModel() { Id = 5, Name = Request.Form["Name"], Surname = Request.Form["Surname"] };

            if (kisi.Id <= 0)
            {
                kisi.Id = maxId;
                kisiler.Add(kisi);
            }
            else
            {
                KisiViewModel updateKisi = kisiler.First(c => c.Id == kisi.Id);
                updateKisi.Name = kisi.Name;
                updateKisi.Surname = kisi.Surname;

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            KisiViewModel model = kisiler.FirstOrDefault(c => c.Id == id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            //var silinecek = kisiler.FirstOrDefault(c => c.Id == id);
            //kisiler.Remove(silinecek);

            kisiler = kisiler.Where(c => c.Id != id).ToList();
            return RedirectToAction(nameof(Index)); 

        }

    }
}
