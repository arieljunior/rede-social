using System;

namespace DomainModel.Entities.Post
{
    public class PostModel
    {
        public PostModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string UrlImage { get; set; }
        public int IdProfile { get; set; }
        
    }
}
