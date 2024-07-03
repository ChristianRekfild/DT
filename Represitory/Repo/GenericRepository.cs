using DT.Model.Data.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DT.Represitory.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        private readonly DbSet<T> _entitySet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _entitySet = _context.Set<T>();
        }

        public virtual T Get(Guid id)
        {
            //return _context.Find(id.ToString());
            return _context.Find<T>(id);
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _context.FindAsync<T>(id);
        }

        public virtual T Add(T entity)
        {
            var returnedEntity = (_context.Add<T>(entity).Entity);
            _context.SaveChanges();
            return returnedEntity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var objToReturn = await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
            return objToReturn.Entity;
        }



        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        

        public T GetWithIncludes(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetWithIncludesAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public T Select(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> SelectAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
