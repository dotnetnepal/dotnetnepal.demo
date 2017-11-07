using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SlugGenerator
    {
        public string CreateSlug(string title)
        {
            string tempTitle = title;
            tempTitle = tempTitle.Replace(" ", "-");
            Regex allowList = new Regex("([^A-Za-z0-9-])");
            string slug = allowList.Replace(tempTitle, "");
            return slug;
        }
    }
}
