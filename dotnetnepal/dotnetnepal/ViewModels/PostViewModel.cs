﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetnepal.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string Excerpt { get; set; }

        public bool PublishPost { get; set; }
    }
}
