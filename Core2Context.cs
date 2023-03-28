using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2
{
    public class Core2Context : DbContext
    {
        public Core2Context(DbContextOptions<Core2Context> options)
        : base(options)
        {
        }
        public DbSet<Core2.dept2> dept2 { get; set; }
        public DbSet<Core2.items2> items2 { get; set; }
    }

}
