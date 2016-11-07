using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyURL.DataStore.Services;

namespace TinyURL.DataStore.Services
{
    public class TinyURLRepository : ITinyURLRepository
    {
        public bool IsExist(string shortUrl)
        {
            using (var context = new TinyURLEntities())
            {
                var data = from uMap in context.URLMappings
                           where uMap.TinyUrl == shortUrl
                           select uMap;
                if (data.FirstOrDefault() != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddShortenedURLMapping(URLMapping urlMapping)
        {
            using (var context = new TinyURLEntities())
            {
                context.URLMappings.Add(urlMapping);
                context.SaveChanges();
            }
        }

        public URLMapping GetURLMapping(string shortenedURL)
        {
            using (var context = new TinyURLEntities())
            {
                var data = from uMap in context.URLMappings
                           where uMap.TinyUrl == shortenedURL
                           select uMap;
                if (data != null)
                {
                    return data.FirstOrDefault();
                }
                return null;
            }
        }
    }
}
