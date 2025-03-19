using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCGamersApp.Models;

namespace MVCGamersApp.Data
{
    public class MVCGamersAppContext : DbContext
    {
        public MVCGamersAppContext (DbContextOptions<MVCGamersAppContext> options)
            : base(options)
        {
        }

        public DbSet<MVCGamersApp.Models.Game> Game { get; set; } = default!;
        public DbSet<MVCGamersApp.Models.Gamer> Gamer { get; set; } = default!;
        public DbSet<MVCGamersApp.Models.GamerPlays> GamerPlays { get; set; } = default!;
    }
}
