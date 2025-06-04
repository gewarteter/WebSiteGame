using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcGame.Models;

namespace MvcGame.Data
{
    public class CharacterContext : DbContext
    {
        public CharacterContext (DbContextOptions<CharacterContext> options)
            : base(options)
        {
        }

        public DbSet<MvcGame.Models.Characters> Characters { get; set; } = default!;
    }
}
