using Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Job
{
    public class JobModel
    {
        public JobModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public List<CompanyModel> ForThisCompany { get; set; }
    }
}
