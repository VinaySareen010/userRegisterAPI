using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,//Filteration
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,//For Sorting/Order By
        string includeProperties = null);//For Joins
      //  T FirstOrDefault(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        T GetById(int id);
        T GetByName(string name);
        bool Save(T objToSave);
        bool Update(T objToUpdate);
        bool Delete(T objToDelete);
        bool Save();
    }
}
