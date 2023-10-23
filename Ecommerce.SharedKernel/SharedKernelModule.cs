using Autofac;
using Ecommerce.SharedKernel.Helpers;
using Ecommerce.SharedKernel.Interfaces;
using Module = Autofac.Module;

namespace Ecommerce.SharedKernel
{
    public class SharedKernelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Culture>().As<ICulture>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<EmailSender>().As<IEmailSender>()
            //    .InstancePerLifetimeScope();
        }
    }
}
