using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Profile
{
    public class CompanyProfileModel : ProfileBaseModel
    {
        public int IdCompany { get; set; }
        public int MyProperty { get; set; }
    }
}
