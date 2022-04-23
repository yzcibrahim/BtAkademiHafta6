using _05_Tipler;
using System.Collections.Generic;

namespace _08_DosyaRepository
{
    public interface IKisiRepository
    {
        List<KisiCls> Get();
        KisiCls GetById(int id);
        void Add(KisiCls kisi);
        void Delete(int id);
        void Update(KisiCls kisi);
    }
}
