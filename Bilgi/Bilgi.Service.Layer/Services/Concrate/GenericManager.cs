using Bilgi.Entity.Layer.Iterfaces;
using Bilgi.Service.Layer.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Service.Layer.Services.Concrate
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGeneric<T> _generic;

        public GenericManager(IGeneric<T> generic)
        {
            _generic = generic;
        }

        public void Delete(T t)
        {
            _generic.Delete(t);
        }

        public void Insert(T t)
        {
            _generic.Insert(t);
        }
        public void Update(T t)
        {
            _generic.Update(t);
        }
        public T TGetByIdFiltre(Expression<Func<T, bool>> filtre)
        {
             return  _generic.TGetByIdByFilter(filtre);
        }

     

        public IEnumerable<T> TGetListAllFiltre(Expression<Func<T, bool>> filtre, params Expression<Func<T, object>>[] inculudes)
        {
            return _generic.TGetListAllByFilter(filtre, inculudes);
        }

        public IEnumerable<T> TGetListAll()
        {
           return _generic.TGetListAll();
        }

        public T TGetById(int id)
        {
            return _generic.TGetById(id);
        }
    }
}
