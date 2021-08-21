﻿using Dungeons.Models;
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
        public DbSet<Dungeons.Models.User> User { get; set; }
        public DbSet<Character> Character { get; set; }
    }
}
