using System.Collections.Generic;

namespace CSharpEgitimKampi301.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetAll();
        T TGetById(int id);
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
    }
}
