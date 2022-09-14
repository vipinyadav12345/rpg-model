using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions<DbContext> options) : base(options)
        {
            
        }
    public DbSet<character> Characters{ get; set; }

    }
}