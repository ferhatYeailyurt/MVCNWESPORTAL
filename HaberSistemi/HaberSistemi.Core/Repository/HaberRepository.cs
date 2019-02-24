using HaberSistemi.Core.InfraStructure;
using HaberSistemi.Data.Model;
using HaberSistemi.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations; // AddOrUpdate için gerekli

namespace HaberSistemi.Core.Repository
{
    public class HaberRepository : IHaberRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.Haber.Count();
        }

        public void Delete(int id)
        {
            var Haber = GetById(id);
            if (Haber!=null)
            {
                _context.Haber.Remove(Haber);
            }
        }

        public Haber Get(Expression<Func<Haber, bool>> expression)
        {
            return _context.Haber.FirstOrDefault(expression);
        }

        public IEnumerable<Haber> GetAll()
        {
            return _context.Haber.Select(x => x); //tüm haberler dönecek.
        }

        public Haber GetById(int id)
        {
            return _context.Haber.FirstOrDefault(x => x.Id == id);//tek bir değer döndürceğimiz zaman
        }

        public IQueryable<Haber> GetMany(Expression<Func<Haber, bool>> expression)
        {
            return _context.Haber.Where(expression);//birden fazla değer döner
        }

        public void Insert(Haber obj)
        {
            _context.Haber.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Haber obj)
        {
            _context.Haber.AddOrUpdate(obj);
        }
    }
}
