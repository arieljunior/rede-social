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
        public Guid Id { get; set; }
        public Guid IdProfile { get; set; }
        public Guid IdPost { get; set; }
        public string UrlPhoto { get; set; }
    }
}