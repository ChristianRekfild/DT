using DT.Model.Data.Base;
using System.Linq.Expressions;

namespace DT.Represitory
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<List<T>> GetAllAsync();

        T Get(Guid id);
        Task<T> GetAsync(Guid id);

        T GetWithIncludes(Guid id);
        Task<T> GetWithIncludesAsync(Guid id);
        
        bool Delete(Guid id);
        Task<bool> DeleteAsync(Guid id);

        T Add(in T sender);
        Task<T> AddAsync(in T sender);

        bool Update(in T sender);
        Task<bool> UpdateAsync(in T sender);

        bool Save();
        Task<bool> SaveAsync();

        public T Select(Expression<Func<T, bool>> predicate);
        public Task<T> SelectAsync(Expression<Func<T, bool>> predicate);
    }
}
