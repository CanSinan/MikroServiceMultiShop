using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(CargoContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Delete(int id)
        {
            var values = _table.Find(id);
            _table.Remove(values);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            var values = _table.ToList();
            return values;
        }

        public T GetById(int id)
        {
            var value = _table.Find(id);
            return value;
        }

        public void Insert(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
        }
    }
}
