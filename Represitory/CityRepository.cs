using DT.Model.Data.Location;
using DT.Represitory.Repo;
using Microsoft.EntityFrameworkCore;

namespace DT.Represitory
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<City> _cities;

        public CityRepository(DbContext context) : base(context) 
        {
            _dbContext = context;
            _cities = context.Set<City>();
        }

        /// <summary>
        /// Получение сущности Region с БД (aсинхронное) с вложенными сущностями
        /// </summary>
        /// <param name="id">Guid Id сущности</param>
        /// <returns></returns>
        public virtual async Task<City> GetWithIncludesAsync(Guid id)
        {
            var city = await _cities.FirstOrDefaultAsync(r => r.Id == id);
            if (city is null) return null;

            _cities.Entry(city).Reference(r => r.Region).Load();

            return city;

            //var item = db.Items
            // .Include(i => i.Category)
            // .Include(i => i.Brand)
            // .Where(x => x.ItemId == id)
            // .First();
        }
    }
}
