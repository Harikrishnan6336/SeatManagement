using System.Linq.Expressions;


namespace SeatManagementDomain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
