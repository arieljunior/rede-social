using DomainModel.Entities.Post;
using System;
using System.Collections.Generic;

namespace DomainModel.Entities.Profile
{
    public class ProfileBaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UrlPhoto { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public DateTime DateCreated { get; set; }
        public List<PostModel> TimeLine { get; set; }
    }
}
