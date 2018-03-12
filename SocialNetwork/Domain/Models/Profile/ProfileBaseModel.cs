using Domain.Models.Post;
using System;
using System.Collections.Generic;

namespace Domain.Models.Profile
{
    public class ProfileBaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime DateCreated { get; set; }
        public List<PostModel> TimeLine { get; set; }
    }
}
