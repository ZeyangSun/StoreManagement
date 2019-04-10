using CompanyManagement.BLL;
using CompanyManagement.IBLL;
using CompanyManagement.Model;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CompanyManagement.UIPortal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<IStoreService, StoreService>();
           
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}