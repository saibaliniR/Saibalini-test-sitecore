using Saibalini_test_sitecore.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Saibalini_test_sitecore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<INewsService, NewsService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}