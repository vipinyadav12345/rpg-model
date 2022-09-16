using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Data
{
    public class DataContext : DbContext
    {
      //  internal object characters;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    public DbSet<character> character { get; set; }
    public DbSet<User> users { get; set; }
    }

}