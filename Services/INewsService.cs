using Saibalini_test_sitecore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saibalini_test_sitecore.Services
{
    public interface INewsService
    {
        NewsListWithFacet GetNewsResult(string order = "Ascending", string filter = "");
    }
}
