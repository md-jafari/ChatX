﻿using ChatX.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChatX.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<History> Historys { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
