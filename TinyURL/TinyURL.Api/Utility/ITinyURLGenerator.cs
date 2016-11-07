using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyURL.Api.Utility
{
    public interface ITinyURLGenerator
    {
        string GetTinyURL(string longURL);
    }
}
