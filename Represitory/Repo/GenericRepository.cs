using DT.Model.Data.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DT.Represitory.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        private readonly DbSet<T> _entitySet;

        /// <summary>
        /// Generic'овый репрезеторий, чтобы не писать лишний раз методы получения, добавления и бла бла бла
        /// </summary>
        /// <param name="context">Контекст данных</param>
        public GenericRepository(DbContext context)
        {
            _context = context;
            _entitySet = _context.Set<T>();
        }

        /// <summary>
        /// Получение сущности с БД (синхронное)
        /// </summary>
        /// <param name="id">Guid Id сущности</param>
        /// <returns></returns>
        public virtual T Get(Guid id)
        {
            return _context.Find<T>(id);
        }

        /// <summary>
        /// Получение сущности с БД (aсинхронное)
        /// </summary>
        /// <param name="id">Guid Id сущности</param>
        /// <returns></returns>
        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _context.FindAsync<T>(id);
        }

        /// <summary>
        /// Добавление сущности в БД (синхронное)
        /// </summary>
        /// <param name="entity">Сущность для добавления</param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            var returnedEntity = _context.Add<T>(entity).Entity;
            _context.SaveChanges();
            return returnedEntity;
        }

        /// <summary>
        /// Добавление сущности в БД (асинхронное)
        /// </summary>
        /// <param name="entity">Сущность для добавления</param>
        /// <returns></returns>
        public virtual async Task<T> AddAsync(T entity)
        {
            var objToReturn = await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
            return objToReturn.Entity;
        }


        /// <summary>
        /// Удаление сущности из БД (синхронное)
        /// </summary>
        /// <param name="id">Сущность для удаления</param>
        /// <returns>true, если успешно. Иначе - false</returns>
        public bool Delete(Guid id)
        {
            var entity = _context.Find<T>(id);
            if (entity != null)
            {
                _context.Remove(entity);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Удаление сущности из БД (фсинхронное)
        /// </summary>
        /// <param name="id">Сущность для удаления</param>
        /// <returns>true, если успешно. Иначе - false</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.FindAsync<T>(id);
            if (entity != null)
            {
                _context.Remove(entity);
                return true;
            }
            return false;
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
