using System;

namespace DomainModel.Entities.Post
{
    public class PostModel
    {
        public int IdPost { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string UrlImage { get; set; }
        public bool Type { get; set; }
        public int IdProfile { get; set; }

        public string GeType()
        {
            return Type ? "challenge" : "common";
        }
    }
}
