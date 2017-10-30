using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public static string Title { get; private set; }
        public static string Description { get; private set; }
        public static string Image { get; private set; }
    }
}
