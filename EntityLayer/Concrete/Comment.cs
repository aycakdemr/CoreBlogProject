﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentUserName { get; set; }
        public string CommentContent { get; set; }
        public string CommentTitle { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
    }
}
