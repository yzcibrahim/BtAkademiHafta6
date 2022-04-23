using _05_Tipler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DosyaRepository
{
    public class BtaKisiDbContext:DbContext
    {
        public BtaKisiDbContext(DbContextOptions<BtaKisiDbContext> options):base(options)
        {

        }

        public DbSet<KisiCls> Kisiler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
    }
}
