using Domain.Models.PostModel;
using System;
using System.Collections.Generic;

namespace Domain.Models.ProfileModel
{
    public class ProfileBase
    {
        public string Name { get; private set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Post> TimeLine { get; set; }
    }
}
