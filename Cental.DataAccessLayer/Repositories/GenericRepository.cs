﻿using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : BaseEntity


    {
        protected readonly CentalContext _context;

        public GenericRepository(CentalContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var values = GetById(id);
            _context.Remove(values);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
          return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();

        }
    }
}
