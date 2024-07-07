using Saibalini_test_sitecore.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saibalini_test_sitecore.Services
{
    public class NewsService : INewsService
    {
        public NewsListWithFacet GetNewsResult(string order = "Ascending", string filter = "")
        {
            NewsListWithFacet newsListWithFacet = new NewsListWithFacet();
            List<NewsModel> results = null;
            using (var context = ContentSearchManager.GetIndex("sitecore_" + Sitecore.Context.Database.Name.ToLowerInvariant() + "_index").CreateSearchContext())
            {
                var facets = filter.Split(',');
                var query = context.GetQueryable<NewsModel>()
                    .Where(item => item.Path.StartsWith("/sitecore/content/News/News/") &&
                        item.TemplateName == "News");
                if (order=="Ascending" && facets.Any() && string.IsNullOrEmpty(facets[0]))
                {
                    query = query.OrderBy(i => i.PublishedDate);
                }
                else if (order == "Descending" && facets.Any() && string.IsNullOrEmpty(facets[0]))
                {
                    query = query.OrderByDescending(i => i.PublishedDate);
                }
                else if (order == "Ascending" && facets.Any() && !string.IsNullOrEmpty(facets[0]))
                {
                    query = query.Where(i => facets.Contains(i.Category)).OrderBy(i => i.PublishedDate);
                }
                else if (order == "Descending" && facets.Any() && !string.IsNullOrEmpty(facets[0]))
                {
                    query = query.Where(i => facets.Contains(i.Category)).OrderByDescending(i => i.PublishedDate);
                }
                else if (facets.Any() && !string.IsNullOrEmpty(facets[0]))
                {
                    query = query.Where(i=>facets.Contains(i.Category));
                }
                
                results = query
                    .ToList();
            }
            newsListWithFacet.NewsModels = results;
            newsListWithFacet.NewsFacets=GetNewsFacetsWithCount();
            return newsListWithFacet;
        }
        public List<Dictionary<string,int>> GetNewsFacetsWithCount()
        {
            List<Dictionary<string, int>> facetNameAndCountList = new List<Dictionary<string, int>>();
            using (var context = ContentSearchManager.GetIndex("sitecore_" + Sitecore.Context.Database.Name.ToLowerInvariant() + "_index").CreateSearchContext())
            {
                var res = context.GetQueryable<NewsModel>()
                    .Where(item => item.Path.StartsWith("/sitecore/content/News/News/") &&
                        item.TemplateName == "News").FacetOn(t => t["category"], 1)
                        //.FacetOn(t => t.PublishedDate, 1)
                        .GetResults();
                if (res.Facets != null && res.Facets.Categories.Any())
                {
                    FacetCategory categories = res.Facets.Categories.First(x => x.Name.Equals("category"));
                    if (categories != null && categories.Values.Any())
                    {
                        foreach (FacetValue facet in categories.Values)
                        {
                            Dictionary<string, int> facetDict = new Dictionary<string, int>();
                            int facetCount = facet.AggregateCount;
                            string facetValue = facet.Name;
                            facetDict.Add(facetValue, facetCount);
                            facetNameAndCountList.Add(facetDict);
                        }
                    }

                }
               
            }
            return facetNameAndCountList;
        }
    }
}