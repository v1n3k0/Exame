using Exame.Dominio.Interfaces.Repositories;
using Exame.Dominio.Interfaces.Repositories.Base;
using Exame.Dominio.Interfaces.Services;
using Exame.Dominio.Services;
using Exame.Infra.Persistence;
using Exame.Infra.Persistence.Repositories;
using Exame.Infra.Persistence.Repositories.Base;
using Exame.Infra.Transactions;
using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;

namespace XProjeto.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, ExameContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IServiceProduto, ServiceProduto>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceCosif, ServiceCosif>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceMovimento, ServiceMovimento>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            container.RegisterType<IRepositoryProduto, RepositoryProduto>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryCosif, RepositoryCosif>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryMovimento, RepositoryMovimento>(new HierarchicalLifetimeManager());

        }
    }
}
