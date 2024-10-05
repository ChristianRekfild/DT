using DT.Model.Data.Location;
using DT.Represitory.Repo;

namespace DT.Represitory
{
    public interface IRegionRepository : IGenericRepository<Region>
    {
        public Task<Region> GetWithIncludesAsync(Guid id);
        public Task<Region> GetWithIncludes(Guid id);

    }
}
