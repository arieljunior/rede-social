using System;

namespace Domain.Models.Post
{
    public class PostModel
    {
        public int IdPost { get; set; }
        public DateTime Date { get; set; }
        public String Content { get; set; }
        public int IdProfile { get; set; }
    }
}
