using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FeedViewModel
    {
        public Guid MyId { get; set; }
        public string MyName { get; set; }
        public string MyElo { get; set; }
        public string MyHonors { get; set; }
        public string MyMensage { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string MensageFromPost { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }
}