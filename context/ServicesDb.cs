using Microsoft.EntityFrameworkCore;
using serviceApi.Data;
using serviceApi.models;

namespace serviceApi.context
{
    public class ServicesDb: DbContext
    {
        public ServicesDb(DbContextOptions<ServicesDb> options): base(options) {
            DbInitializer.Initialize(this);
        }

        
        public DbSet<ServicesModel> ServicesItems { get; set; } = null!;
        public DbSet<UserModel> Users { get; set; } = null!;
    }
}