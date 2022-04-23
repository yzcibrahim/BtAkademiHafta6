using _05_Tipler;
using _08_DosyaRepository;
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

        IKisiRepository _repository;
        Test _t1;
        public KisiController(IKisiRepository jsonRepository, Test t1,IDeneme d1, IDeneme d2, IDeneme d3)
        {
            
            if (kisiler == null)
            {
                kisiler = new List<KisiViewModel>();
                //kisiler.Add(new KisiViewModel() { Id = 1, Name = "İbrahim", Surname = "Yazıcı" });
                //kisiler.Add(new KisiViewModel() { Id = 2, Name = "Cem", Surname = "Akdemir" });
                //kisiler.Add(new KisiViewModel() { Id = 3, Name = "Elif", Surname = "Müftüoğlu" });
            }

            //  _repository = new JsonRepository();
            _repository = jsonRepository;

            //  _t1 = new Test();
            _t1 = t1;

        }

        [HttpGet]
        public IActionResult Index()
        {

            List<KisiCls> kisilerDto = _repository.Get();
            //KisiViewModel model = new KisiViewModel() { Id = 1, Name = "ibrahim", Surname = "Yazıcı" };
            List<KisiViewModel> model = new List<KisiViewModel>();

            foreach (var item in kisilerDto)
            {
                KisiViewModel kisi = new KisiViewModel()
                {
                    Id = item.Id,
                    Name = item.Ad,
                    Surname = item.Soyad,
                    Age = item.Yas

                };
                model.Add(kisi);
            }
            kisiler = model;

            return View(model);
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
            //KisiViewModel yeniKisi = new KisiViewModel() { Id = maxId, Name = Name, Surname = Surname };
            //  KisiViewModel yeni = new KisiViewModel() { Id = 5, Name = Request.Form["Name"], Surname = Request.Form["Surname"] };

            KisiCls kisiCls = new KisiCls();
           
            kisiCls.Ad = kisi.Name;
            kisiCls.Soyad = kisi.Surname;
            kisiCls.Yas = kisi.Age;
            if (kisi.Id <= 0)
            {
                kisiler.Add(kisi);
                kisiCls.Id = kisi.Id;

                _repository.Add(kisiCls);
            }
            else
            {
                kisiCls.Id = kisi.Id;
                _repository.Update(kisiCls);

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

            _repository.Delete(id);
          //  _repository.Save()

            return RedirectToAction(nameof(Index));

        }

    }
}
