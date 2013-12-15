using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ServiceModel.Syndication;
using FestivalSite.Models.DAL;
using FestivalSite.Models;

namespace FestivalSite.Controllers
{
    public class RSSController : ApiController
    {


        public Rss20FeedFormatter GetFeed()
        {
            List<News> news = NewsRepository.GetNews();

            var feed = new SyndicationFeed("Nieuwsoverzicht van het festival", "Description", new Uri("http://localhost:8080"));
            feed.Authors.Add(new SyndicationPerson("Festival naam"));
            feed.Categories.Add(new SyndicationCategory("Festival"));
            feed.Description = new TextSyndicationContent("This is a how to sample that demonstrates how to expose a feed using RSS with WCF");

            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach (News n in news)
            {
                SyndicationItem item = new SyndicationItem(
                n.Title,
                n.Content,
                new Uri("http://localhost:51172/"),
                n.Id,
                n.Date);
                item.Authors.Add(new SyndicationPerson(n.Author));

                items.Add(item);
            }
            feed.Items = items;

            return new Rss20FeedFormatter(feed);
        }




    }
}
