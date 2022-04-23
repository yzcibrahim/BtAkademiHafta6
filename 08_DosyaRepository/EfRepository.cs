using _05_Tipler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DosyaRepository
{
    public class EfRepository : IKisiRepository
    {
        BtaKisiDbContext _context;
        public EfRepository(BtaKisiDbContext context)
        {
            _context = context;
        }
        public void Add(KisiCls kisi)
        {
            _context.Add(kisi);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            KisiCls silinecek = GetById(id);
            _context.Remove(silinecek);
            _context.SaveChanges();
        }

        public List<KisiCls> Get()
        {
            return _context.Set<KisiCls>().ToList();
        }

        public KisiCls GetById(int id)
        {
            return _context.Set<KisiCls>().Find(id);
        }

        public void Update(KisiCls kisi)
        {
            _context.Attach<KisiCls>(kisi);
            _context.Entry(kisi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
