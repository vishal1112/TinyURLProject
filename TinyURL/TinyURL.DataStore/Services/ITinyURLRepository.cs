using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL.DataStore.Services
{
    public interface ITinyURLRepository
    {
        bool IsExist(string shortUrl);
        void AddShortenedURLMapping(URLMapping urlMapping);
        URLMapping GetURLMapping(string shortenedURL);
    }
}
