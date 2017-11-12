﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetnepal.ViewModels
{
    public class PostSummaryModel
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public DateTimeOffset PublishTime { get; set; }
        public string Excerpt { get; set; }
        public int CommentCount { get; set; }
    }
}
