using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        T GetByName(string name);
        bool Save(T objToSave);
        bool Update(T objToUpdate);
        bool Delete(T objToDelete);
        bool Save();
    }
}
