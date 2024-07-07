using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Controllers;
using Saibalini_test_sitecore.Models;
using Saibalini_test_sitecore.Services;


namespace Saibalini_test_sitecore.Controllers
{
    public class NewsController : SitecoreController
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        public ActionResult GetNewsResult()
        {
            NewsListWithFacet results = _newsService.GetNewsResult();
            return View("NewsList",results);
        }
        [HttpPost]
        public ActionResult NewsResult(string order, string filter)
        {
            NewsListWithFacet results = _newsService.GetNewsResult(order, filter);
            return View("NewsList", results);
        }

    }
}