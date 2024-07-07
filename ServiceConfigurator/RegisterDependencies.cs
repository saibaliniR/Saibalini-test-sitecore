using Microsoft.Extensions.DependencyInjection;
using Saibalini_test_sitecore.Controllers;
using Saibalini_test_sitecore.Services;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saibalini_test_sitecore.ServiceConfigurator
{
    public class RegisterDependencies: IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(INewsService), typeof(NewsService));
            serviceCollection.AddTransient<NewsController>();
        }
    }
}