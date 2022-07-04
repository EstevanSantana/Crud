using Crud.BackEnd.Domain.Core.Data;
using Crud.BackEnd.Domain.Core.Mediator;
using Crud.BackEnd.Domain.Core.Messages;
using Crud.BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.BackEnd.Infra.Data.Context
{
    public class DataContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DataContext(DbContextOptions<DataContext> options, IMediatorHandler mediatorHandler) : base(options) 
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            var success = await base.SaveChangesAsync() > 0;
            if (success) await _mediatorHandler.PublishDomainEvents(this);

            return success;
        }
    }
}
