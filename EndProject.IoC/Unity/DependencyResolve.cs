using System.Data.Entity;
using EndProject.Infra.Persistence;
using EndProject.Infra.Persistence.Repositores;
using EndProject.Infra.Persistence.Repositores.Base;
using EndProject.Infra.Transaction;
using EndProject.Service.Interfaces;
using EndProject.Service.Repositories;
using EndProject.Service.Repositories.Base;
using EndProject.Service.Service;
using prmToolkit.NotificationPattern;
using Unity;
using Unity.Lifetime;

namespace EndProject.IoC.Unity
{
  public static class DependencyResolve
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, EndProjectContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IServicePlayer, ServicePlayer>(new HierarchicalLifetimeManager());



            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoyBase<,>));

            container.RegisterType<IRepositoryPlayer, RepositoryPlayer>(new HierarchicalLifetimeManager());



        }
    }
}
