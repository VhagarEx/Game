using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Game.Data
{
    public class GameContext : DbContext
    {
        public GameContext (DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<Gamer> Gamer { get; set; } = default!;
        public DbSet<Level> Level { get; set; } = default!;
        public DbSet<Character> Character { get; set; } = default!;
    }
}
