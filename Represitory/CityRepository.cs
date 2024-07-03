using DT.Model.Data.Location;
using DT.Represitory.Repo;
using Microsoft.EntityFrameworkCore;

namespace DT.Represitory
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Region> _regions;

        public CityRepository(DbContext context) : base(context) { }
    }
}
