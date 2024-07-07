using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch;

namespace Saibalini_test_sitecore.Models
{
    public class NewsListWithFacet
    {
        public List<NewsModel> NewsModels { get; set; }
        public List<Dictionary<string, int>> NewsFacets { get; set; }
    }
    public class NewsModel : SearchResultItem, IObjectIndexers
    {
        [IndexField("title")]
        public virtual string Title { get; set; }
        [IndexField("published_date")]
        public virtual DateTime PublishedDate { get; set; }
        [IndexField("category")]
        public virtual string Category { get; set; }
        [IndexField("description")]
        public virtual string Description { get; set; }
    }
}