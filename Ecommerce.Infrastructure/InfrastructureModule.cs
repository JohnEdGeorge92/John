using Autofac;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.DBContexts;
using Ecommerce.Infrastructure.Repositories;
using Module = Autofac.Module;
using Ecommerce.Core.Interfaces.Repositories;

namespace Ecommerce.Infrastructure
{
    public class InfrastructureModule<T> : Module where T : DbContext
    {
        // IOC Container Methods
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork<T>>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }
    }
}
