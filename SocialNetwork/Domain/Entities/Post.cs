using System;

namespace DomainModel.Entities
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string UrlImage { get; set; }
        public Guid IdProfile { get; set; }
        public string Name { get; set; }
        public string UrlPhotoAutor { get; set; }
    }
}
