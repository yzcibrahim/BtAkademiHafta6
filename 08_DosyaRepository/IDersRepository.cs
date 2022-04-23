using _05_Tipler;
using System.Collections.Generic;

namespace _08_DosyaRepository
{
    public interface IDersRepository
    {
        List<Ders> Get();
        Ders GetById(int id);
        void Add(Ders kisi);
        void Delete(int id);
        void Update(Ders kisi);
    }
}
