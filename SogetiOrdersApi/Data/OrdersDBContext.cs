﻿namespace SogetiOrdersApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class OrdersContext : DbContext
    {
        public DbSet<Models.Order> Orders { get; set; }

        public string DbPath { get; }

        public OrdersContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Orders.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
