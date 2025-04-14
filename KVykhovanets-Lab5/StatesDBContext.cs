//using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using KVykhovanets_Lab5.Models.TableModels;

namespace KVykhovanets_Lab5
{
    public class StatesDBContext : DbContext
    {
        public StatesDBContext(DbContextOptions<StatesDBContext> options)
           : base(options)
        {
        }
        public DbSet<States> States { get; set; }
    }
}
