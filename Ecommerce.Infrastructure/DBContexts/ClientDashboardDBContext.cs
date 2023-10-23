using Microsoft.EntityFrameworkCore;
using Ecommerce.SharedKernel.Consts;
using System.Reflection.Emit;
using Ecommerce.Core.Entities;

namespace Ecommerce.Infrastructure.DBContexts
{
    public class ClientDashboardDBContext : DbContext
    {
        public ClientDashboardDBContext(DbContextOptions<ClientDashboardDBContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
        public virtual DbSet<Customer> Customer { get; set; } = null;
        public virtual DbSet<Product> Product { get; set; } = null;
        public virtual DbSet<Order> Order { get; set; } = null;
        public virtual DbSet<OrderLine> OrderLine { get; set; } = null;
    }
        
}
