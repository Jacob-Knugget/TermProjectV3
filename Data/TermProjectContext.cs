using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Data
{
    public class TermProjectContext : DbContext
    {
        public TermProjectContext (DbContextOptions<TermProjectContext> options)
            : base(options)
        {
        }

        public DbSet<TermProject.Models.BodyGroup> BodyGroup { get; set; } = default!;
    }
}
