using Autofac;
using Autofac.Integration.Mvc;
using ContactTask.PresentationService;
using ContactTask.PresentationService.Interfaces;
using ContactTaskDomain.DomainServices.Interfaces;
using ContactTaskDomain.Repositories;
using ContactTaskDomain.UnitOfWork;
using ContactTaskInfrastructure.Context;
using ContactTaskInfrastructure.Repositories;
using ContactTaskInfrastructure.UnitOfWork;
using System.Reflection;
using System.Web.Mvc;

namespace ContactTask.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ContextDatabase>().As<IContextDatabase>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IBasePresentationService).Assembly)
                .Where(t => typeof(IBasePresentationService).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(IBaseDomainService).Assembly)
               .Where(t => typeof(IBaseDomainService).IsAssignableFrom(t))
               .AsImplementedInterfaces()
               .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                .AsClosedTypesOf(typeof(IBaseRepository<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterFilterProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}