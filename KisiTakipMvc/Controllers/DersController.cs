using _05_Tipler;
using _08_DosyaRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiTakipMvc.Controllers
{
    public class DersController : Controller
    {
        IDersRepository _repository;
        public DersController(IDersRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {

            List<Ders> model = _repository.Get();
            return View(model);
        }

        public PartialViewResult ListDersPartial()
        {
            List<Ders> model = _repository.Get();
            model.Add(new Ders() { Ad = "sonradan eklendi action method", Id = 500, Kredi = 140 });
            return PartialView(model);

        }
    }
}
