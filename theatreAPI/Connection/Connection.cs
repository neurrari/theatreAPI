using Microsoft.EntityFrameworkCore;
using theatreAPI.Models;

namespace theatreAPI.Connection
{
    public class TypeOfStoringDb : DbContext
    {
        public TypeOfStoringDb(DbContextOptions<TypeOfStoringDb> options)
            : base(options) { }

        public DbSet<TypeOfStoring> TypesOfStoring => Set<TypeOfStoring>();
    }

    public class ReceptionWaysDb : DbContext
    {
        public ReceptionWaysDb(DbContextOptions<ReceptionWaysDb> options)
            : base(options) { }
        
        public DbSet<ReceptionWays> ReceptionWay => Set<ReceptionWays>();
    }
    public class WorkTechniqueDb : DbContext
    {
        public WorkTechniqueDb(DbContextOptions<WorkTechniqueDb> options)
            : base(options) { }

        public DbSet<WorkTechnique> WorkTechniques => Set<WorkTechnique>();
    }

    public class StorageDb : DbContext
    {
        public StorageDb(DbContextOptions<StorageDb> options)
            : base(options) { }

        public DbSet<StoragePlaces> Storages => Set<StoragePlaces>();
    }

    public class PositionDb : DbContext
    {
        public PositionDb(DbContextOptions<PositionDb> options)
            : base(options) { }

        public DbSet<Position> Positions => Set<Position>();
    }

}
