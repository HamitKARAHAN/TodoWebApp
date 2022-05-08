﻿using Example.TodoWebApp.Data.Configurations;
using Example.TodoWebApp.Data.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.TodoWebApp.Data.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<Work> Works { get; set; }
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
        }
    }
}
