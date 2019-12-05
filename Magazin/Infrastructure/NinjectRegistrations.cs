using DataLayer.Repositories;
using Ninject.Modules;
using Service.Services;


namespace Magazin.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IItemRepository>().To<ItemRepository>();
            Bind<IItemService>().To<ItemService>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<ICustomerService>().To<CustomerService>();


            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IStatusRepository>().To<StatusRepository>();
            Bind<IStatusService>().To<StatusService>();


            //Bind<IOrderProcess>().To<OrderProcess>();
            //var builder = new ContainerBuilder();
            //builder.Register(cfg => AutomapperProfileConfig.SetupMappings()).AsSelf().SingleInstance();
            //builder.Register(cfg => cfg.Resolve<MapperConfiguration>().CreateMapper(cfg.Resolve)).As<IMapper>()
            //                .InstancePerLifetimeScope();
            //ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(builder.Build()));
        }
    }
}