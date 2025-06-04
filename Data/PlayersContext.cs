using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcGame.Models;

namespace MvcGame.Data
{
    public class PlayersContext : DbContext
    {
        public PlayersContext (DbContextOptions<PlayersContext> options)
            : base(options)
        {
        }

        public DbSet<MvcGame.Models.Players> Players { get; set; } = default!;
    }
}
