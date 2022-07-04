using Crud.BackEnd.Domain.Core.DomainObjects;
using Crud.BackEnd.Domain.Core.Mediator;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.BackEnd.Infra.Data.Context
{
    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents(this IMediatorHandler mediator, DataContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notification != null && x.Entity.Notification.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notification)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvent());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
