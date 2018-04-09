using System;
using System.Collections.Generic;

namespace DomainModel.Entities
{
    public class Profile
    {
        public Guid Id { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UrlPhoto { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
