using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CommentsFromPost
    {
        public CommentsFromPost()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid IdPost { get; set; }
        public Guid IdProfile { get; set; }
        public string Comment { get; set; }
        public DateTime DateComment { get; set; }
        public string Name { get; set; }
    }
}
