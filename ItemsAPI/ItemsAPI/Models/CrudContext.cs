using System;
using Microsoft.EntityFrameworkCore;

namespace ItemsAPI.Models
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options)
            : base(options)
        {
        }

        public DbSet<CrudItem> CrudItems { get; set; }
    }
}
