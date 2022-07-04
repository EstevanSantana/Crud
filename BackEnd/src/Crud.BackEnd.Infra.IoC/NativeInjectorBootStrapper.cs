using Crud.BackEnd.Application.Commands;
using Crud.BackEnd.Application.Events;
using Crud.BackEnd.Application.Queries;
using Crud.BackEnd.Domain.Core.Mediator;
using Crud.BackEnd.Domain.Core.Messages.Notifications;
using Crud.BackEnd.Domain.Interfaces;
using Crud.BackEnd.Infra.Data.Context;
using Crud.BackEnd.Infra.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.BackEnd.Infra.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Core - Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Core - Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Application - Commands
            services.AddScoped<IRequestHandler<RegisterNewUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand, bool>, UserCommandHandler>();

            // Application - Events 
            services.AddScoped<INotificationHandler<RegisterUserEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UpdateUserEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<RemoveUserEvent>, UserEventHandler>();

            // Application - Queries 
            services.AddScoped<IUserQueries, UserQueries>();

            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<DataContext>();
        }
    }
}
