using _05_Tipler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DosyaRepository
{
    public class DersRepository : IDersRepository
    {
        BtaKisiDbContext _context;
        public DersRepository(BtaKisiDbContext context)
        {
            _context = context;
        }
        public void Add(Ders ders)
        {
            _context.Add(ders);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Ders silinecek = GetById(id);
            _context.Remove(silinecek);
            _context.SaveChanges();
        }

        public List<Ders> Get()
        {
            return _context.Set<Ders>().ToList();
        }

        public Ders GetById(int id)
        {
            return _context.Set<Ders>().Find(id);
        }

        public void Update(Ders ders)
        {
            _context.Attach<Ders>(ders);
            _context.Entry(ders).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
