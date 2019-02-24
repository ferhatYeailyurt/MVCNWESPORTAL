using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HaberSistemi.Core.InfraStructure
{
    public interface IRepository<T> where T: class
    {

        IEnumerable<T> GetAll(); //tüm datalarımızı çekcek.

        T GetById(int id); // tek bir nesne döndürecek

        T Get(Expression<Func<T, bool>> expression);

        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);

        void Insert(T obj);

        void Update(T obj);


        void Delete(int id);

        int count();

        void Save();

    }
}
