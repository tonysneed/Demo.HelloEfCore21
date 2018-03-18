﻿using Microsoft.EntityFrameworkCore;

namespace HelloEf21
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
