using Domain.Common;
using Domain.Entitis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions options) : base(options) { }

        public DbSet<ToDoTask> Tasks { get; set; }

        public async Task<int> SaveChangesAsynch()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach(var entityEntry in entries)
            {
                ((AuditableEntity)entityEntry.Entity).LastModified = DateTime.UtcNow;

                if(entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).Created = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync();
        }

    }
}
