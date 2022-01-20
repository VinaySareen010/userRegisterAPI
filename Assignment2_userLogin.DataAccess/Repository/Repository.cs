using Assignment2_userLogin.DataAccess.Repository.IRepository;
using Assignment2_userLogin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        internal DbSet<T> dbset;
        public Repository(ApplicationDBContext context)
        {
            _context = context;
            this.dbset = _context.Set<T>();
        }
        public bool Delete(T objToDelete)
        {
            dbset.Remove(objToDelete);
            return Save();
        }

        public ICollection<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public T GetByName(string name)
        {
            return dbset.Find(name);
        }

        public bool Save(T objToSave)
        {
            dbset.Add(objToSave);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool Update(T objToUpdate)
        {
            dbset.Update(objToUpdate);
            return Save();
        }
    }
}
