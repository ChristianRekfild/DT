using DT.Model.Data.Location;
using DT.Represitory.Repo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DT.Represitory
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Region> _regions;

        public RegionRepository(DbContext context) : base(context) 
        {
            _dbContext = context;
            _regions = _context.Set<Region>();
        }

        /// <summary>
        /// Получение сущности Region с БД (aсинхронное) с вложенными сущностями
        /// </summary>
        /// <param name="id">Guid Id сущности</param>
        /// <returns></returns>
        public virtual async Task<Region> GetWithIncludesAsync(Guid id)
        {
            var region = await _regions.FirstOrDefaultAsync(r => r.Id == id);

            if (region is null) return null;

            return await _regions.Where(x => x.Id == id).Include(c => c.Cities).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Получение сущности Region с БД (синхронное) с вложенными сущностями
        /// </summary>
        /// <param name="id">Guid Id сущности</param>
        /// <returns></returns>
        public virtual async Task<Region> GetWithIncludes(Guid id)
        {
            var region = _regions.FirstOrDefault(r => r.Id == id);

            if (region is null) return null;

            return _regions.Where(x => x.Id == id).Include(c => c.Cities).FirstOrDefault();
        }
    }
}
