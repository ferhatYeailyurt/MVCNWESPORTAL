﻿using HaberSistemi.Core.InfraStructure;
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

    public class ResimRepository : IResimRepository
    {
        private readonly HaberContext _context = new HaberContext();

        public int count()
        {
            return _context.Resim.Count();
        }

        public void Delete(int id)
        {
            var Resim = GetById(id);
            if (Resim != null)
            {
                _context.Resim.Remove(Resim);
            }
        }

        public Resim Get(Expression<Func<Resim, bool>> expression)
        {
            return _context.Resim.FirstOrDefault(expression);
        }

        public IEnumerable<Resim> GetAll()
        {
            return _context.Resim.Select(x => x); // tüm resimleri döndürecek
        }   

            public Resim GetById(int id)
            {
                return _context.Resim.FirstOrDefault(x => x.Id == id);
            }

            public IQueryable<Resim> GetMany(Expression<Func<Resim, bool>> expression)
            {
                return _context.Resim.Where(expression);
            }

            public void Insert(Resim obj)
            {
                _context.Resim.Add(obj);
            }

            public void Save()
            {
                _context.SaveChanges();
            }

            public void Update(Resim obj)
            {
                _context.Resim.AddOrUpdate(obj);
            }
        }
    } 
