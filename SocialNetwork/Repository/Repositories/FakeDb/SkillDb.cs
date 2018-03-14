using Domain.Models.Skill;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.FakeDb
{
    public class SkillDb
    {
        private static List<SkillModel> SkillData = new List<SkillModel>();

        public bool Save(SkillModel obj)
        {
            try
            {
                SkillData.Add(obj);

                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        public List<SkillModel> GetAll()
        {
            return SkillData;
        }

        public SkillModel GetById(int id)
        {
            foreach (var skill in SkillData)
            {
                if (id == skill.IdSkill)
                {
                    return skill;
                }
            }

            return null;
        }

        public bool Remove(int id)
        {
            foreach (var skill in SkillData)
            {
                if (id == skill.IdSkill)
                {
                    SkillData.Remove(skill);
                    return true;
                }
            }

            return false;
        }
    }
}
