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
    public class RoleRepository : IRoleRepository
    {
        private readonly HaberContext context= new HaberContext();
        public int count()
        {
            return context.Rol.Count();
        }

        public void Delete(int id)
        {
            var Rol = GetById(id);
            if (Rol!=null)
            {
                context.Rol.Remove(Rol);
            }
        }

        public Rol Get(Expression<Func<Rol, bool>> expression)
        {
            return context.Rol.FirstOrDefault(expression);
        }

        public IEnumerable<Rol> GetAll()
        {
            return context.Rol.Select(x => x);  //tüm roller gelecek
        }

        public Rol GetById(int id)
        {
            return context.Rol.FirstOrDefault(x=>x.Id==id);
        }

        public IQueryable<Rol> GetMany(Expression<Func<Rol, bool>> expression)
        {
            return context.Rol.Where(expression);
        }

        public void Insert(Rol obj)
        {
            context.Rol.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Rol obj)
        {
            context.Rol.AddOrUpdate(obj);
        }
    }
}
