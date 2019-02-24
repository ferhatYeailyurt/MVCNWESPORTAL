using HaberSistemi.Core.InfraStructure;
using HaberSistemi.Data.DataContext;
using HaberSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Core.Repository
{
    public class KategoriRepository : IKategoriRepository
    {
        private readonly HaberContext context = new HaberContext();

        public int count()
        {
            return context.Kategori.Count();
        }

        public void Delete(int id)
        {
            var Kategori = GetById(id);
            if (Kategori!=null)
            {
                context.Kategori.Remove(Kategori);

            }
        }

        public Kategori Get(Expression<Func<Kategori, bool>> expression)
        {
            return context.Kategori.FirstOrDefault(expression);
        }

        public IEnumerable<Kategori> GetAll()
        {
            return context.Kategori.Select(x => x);
        }

        public Kategori GetById(int id)
        {
            return context.Kategori.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Kategori> GetMany(Expression<Func<Kategori, bool>> expression)
        {
            return context.Kategori.Where(expression);
        }

        public void Insert(Kategori obj)
        {
             context.Kategori.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Kategori obj)
        {
            context.Kategori.AddOrUpdate(obj);
        }
    }
}
