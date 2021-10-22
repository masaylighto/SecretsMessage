using Microsoft.EntityFrameworkCore;
using SecretMessging.Models;

namespace SecretMessging.DatabaseContext
{
    public class sqlite : DbContext
    {
        public sqlite(DbContextOptions<sqlite> optionsBuilder) : base(optionsBuilder)
        {

        }
        public DbSet<message> message { get; set; }

    }
}
