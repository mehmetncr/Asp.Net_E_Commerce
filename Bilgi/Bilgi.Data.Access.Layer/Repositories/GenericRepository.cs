using Bilgi.Data.Access.Layer.Contexts;
using Bilgi.Entity.Layer.Iterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Bilgi.Data.Access.Layer.Repositories
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly BilgiContext _context;

        public GenericRepository(BilgiContext context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public void Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }
        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
        public T TGetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public IEnumerable<T> TGetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public T TGetByIdByFilter(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            T nesne = query.FirstOrDefault(filter);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            nesne = query.FirstOrDefault(filter);
            return nesne;

        }

        public IEnumerable<T> TGetListAllByFilter(Expression<Func<T, bool>> filter ,params Expression<Func<T, object>>[] includes)
        {
            //return _context.Set<T>().Where(filter).ToList();

            IQueryable<T> query = _context.Set<T>().Where(filter);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;

        }

   
    }
}
