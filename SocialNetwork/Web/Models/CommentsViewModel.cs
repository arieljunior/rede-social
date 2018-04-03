using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CommentsViewModel
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}