using Domain.Models.Skill;
using Repository.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.FakeDb
{
    public class SkillDb : IRepositoryBase<SkillModel>
    {
        private static List<SkillModel> SkillData = new List<SkillModel>();

        public bool Add(SkillModel obj)
        {
            throw new NotImplementedException();
        }

        public List<SkillModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public SkillModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(SkillModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
