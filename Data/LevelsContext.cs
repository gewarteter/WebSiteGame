using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcGame.Models;

namespace MvcGame.Data
{
    public class LevelsContext : DbContext
    {
        public LevelsContext (DbContextOptions<LevelsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcGame.Models.Levels> Levels { get; set; } = default!;
    }
}
