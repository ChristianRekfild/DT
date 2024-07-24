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
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Удаление сущности из БД (асинхронное)
        /// </summary>
        /// <param name="id">Сущность для удаления</param>
        /// <returns>true, если успешно. Иначе - false</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.FindAsync<T>(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
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
            if (_context.SaveChanges() > 0)
                return true;
            
            return false;
        }

        // TODO использовать токен отмены потом
        public async Task<bool> SaveAsync()
        {
            if (await _context.SaveChangesAsync(true) > 0)
                return true;
            return false;
        }




        public T SelectFirst(Expression<Func<T, bool>> predicate)
        {
            T first = _context.Set<T>().Where(predicate).FirstOrDefault();

            return first;
        }

        public async Task<T> SelectFirstAsync(Expression<Func<T, bool>> predicate)
        {
            T first = await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();

            return first;
        }



        public T Select(Expression<Func<T, bool>> predicate)
        {
            T first = _context.Set<T>().Where(predicate).FirstOrDefault();

            return first;
        }

        public async Task<T> SelectAsync(Expression<Func<T, bool>> predicate)
        {
            T first = await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();

            return first;
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
