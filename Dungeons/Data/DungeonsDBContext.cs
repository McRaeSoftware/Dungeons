using Dungeons.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Data
{
    public class DungeonsDBContext : DbContext
    {
        public DungeonsDBContext(DbContextOptions<DungeonsDBContext> options) : base(options)
        {

        }

        // Database Tables
        public DbSet<User> User { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<CharacterBag> CharacterBag { get; set; }
        public DbSet<CharacterEquipped> CharacterEquipped { get; set; }

    }
}
