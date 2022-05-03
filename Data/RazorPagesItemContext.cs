using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using storage.Models;

    public class RazorPagesItemContext : DbContext
    {
        public RazorPagesItemContext (DbContextOptions<RazorPagesItemContext> options)
            : base(options)
        {
        }
        public DbSet<storage.Models.Item> Item { get; set; }
        public DbSet<storage.Models.Material> Material { get; set; }
        public DbSet<storage.Models.User> User { get; set; }
    }