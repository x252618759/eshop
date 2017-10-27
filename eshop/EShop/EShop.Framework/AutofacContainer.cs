using Autofac;
using System.Reflection;
using Autofac.Configuration;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace EShop.Framework
{
    public class AutofacContainer
    {
        public void RegisterDependency()
        {
           var  builder = new ContainerBuilder();

            var IServices = Assembly.Load("Eshop.IServices");
            var Services = Assembly.Load("Eshop.Service");
            builder.RegisterAssemblyTypes(Services, IServices).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
