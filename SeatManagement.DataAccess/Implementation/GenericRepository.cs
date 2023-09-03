using SeatManagementDataAccess.Context;
using SeatManagementDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementDataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly SeatManagementDbContext _reportService;
        public GenericRepository(SeatManagementDbContext context) 
        { 
            _reportService = context;
        }
        public void Add(T entity)
        {
            _reportService.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _reportService.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _reportService.Set<T>().Update(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _reportService.Set<T>().ToList();
        }

        public T GetById(int id) => _reportService.Set<T>().Find(id);

        public void Remove(T entity)
        {
             _reportService.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _reportService.Set<T>().RemoveRange(entities);
        }

    }
}
