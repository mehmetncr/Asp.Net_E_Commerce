using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Entity.Layer.Iterfaces
{
    public interface IGeneric<T> where T : class
    {
        void Insert(T t);   //ekleme
        void Delete(T t);  //silme
        void Update(T t);  //güncelleme
        IEnumerable<T> TGetListAll();  //tüm listeyi çekme
        T TGetById(int id);  //bir ürün çekme
        IEnumerable<T> TGetListAllByFilter(Expression<Func<T, bool>> filter , params Expression<Func<T, object>>[] includes);   //gelen filtreye göre bir liste çekme
        T TGetByIdByFilter(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);  //gelen filtreye göre ürün çekme
    }
}
