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

        public RegionRepository(DbContext context) : base(context) { }

    }
}
