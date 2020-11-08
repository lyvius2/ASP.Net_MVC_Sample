using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppSample.Models;

namespace WebAppSample.Data
{
    public class MvcMountainContext : DbContext
    {
        public MvcMountainContext (DbContextOptions<MvcMountainContext> options) : base(options)
        {
        }

        public DbSet<Mountain> Mountain { get; set; }
    }
}
