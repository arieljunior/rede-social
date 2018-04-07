using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PostViewModel
    {
        public string Name { get; set; }
        public string Elo { get; set; }
        public DateTime DatePosted { get; set; }
        public string Mensage { get; set; }
        public string UrlImage { get; set; }
        public int Like { get; set; }
        public List<CommentsViewModel> Comments { get; set; }
        public string IdPost { get; set; }
        public string IdProfile { get; set; }
    }
}