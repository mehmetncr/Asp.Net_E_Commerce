using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Service.Layer.Services.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        IEnumerable<T> TGetListAllFiltre(Expression<Func<T,bool>> filtre , params Expression<Func<T, object>>[] inculudes);
        T TGetByIdFiltre(Expression<Func<T, bool>> filtre);
        T TGetById(int id);  //bir ürün çekme
        IEnumerable<T> TGetListAll();  //tüm listeyi çekme
    }
}
