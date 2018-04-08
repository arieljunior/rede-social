using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Follow
    {
        public Follow()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid IdFollower { get; set; }
        public Guid IdFollowed { get; set; }
    }
}
