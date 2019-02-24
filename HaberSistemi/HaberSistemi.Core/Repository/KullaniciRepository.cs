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
   public class KullaniciRepository : IKullaniciRepository
    {
        private readonly HaberContext context = new HaberContext();
        public int count()
        {
            return context.Kullanici.Count();
        }

        public void Delete(int id)
        {
            var Kullanici = GetById(id);
            if (Kullanici!=null)
            {
                context.Kullanici.Remove(Kullanici);
            }
        }

        public Kullanici Get(Expression<Func<Kullanici, bool>> expression)
        {
            return context.Kullanici.SingleOrDefault(expression);
        }

        public IEnumerable<Kullanici> GetAll()
        {
           return context.Kullanici.Select(x => x);
        }

        public Kullanici GetById(int id)
        {
            return context.Kullanici.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Kullanici> GetMany(Expression<Func<Kullanici, bool>> expression)
        {
            return context.Kullanici.Where(expression);
        }

        public void Insert(Kullanici obj)
        {
            context.Kullanici.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Kullanici obj)
        {
            context.Kullanici.AddOrUpdate(obj);
        }
    }
}
