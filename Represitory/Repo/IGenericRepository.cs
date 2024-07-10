using DT.Model.Data.Base;
using System.Linq.Expressions;

namespace DT.Represitory.Repo
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        T Get(Guid id);
        Task<T> GetAsync(Guid id);

        T GetWithIncludes(Guid id);
        Task<T> GetWithIncludesAsync(Guid id);

        bool Delete(Guid id);
        Task<bool> DeleteAsync(Guid id);

        T Add(T entity);
        Task<T> AddAsync(T entity);

        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);

        bool Save();
        Task<bool> SaveAsync();

        public T Select(Expression<Func<T, bool>> predicate);
        public Task<T> SelectAsync(Expression<Func<T, bool>> predicate);
    }
}
