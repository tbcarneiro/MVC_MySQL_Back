using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC_MySQL.Models
{
    public class SeguroContext : DbContext
    {
        public SeguroContext(DbContextOptions<SeguroContext> options) : base(options)
        {
        }
        public DbSet<Seguro> Seguros { get; set; }
    }
}
