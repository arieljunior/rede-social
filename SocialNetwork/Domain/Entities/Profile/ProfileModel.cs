using Domain.Entities.Job;
using DomainModel.Entities.Skill;
using System;
using System.Collections.Generic;

namespace DomainModel.Entities.Profile
{
    public class ProfileModel : ProfileBaseModel
    {

        public Guid IdProfile { get; set; }
        public List<SkillModel> Skills { get; set; }
        public List<JobModel> Jobs { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }

        public ProfileModel()
        {
            IdProfile = Guid.NewGuid();
        }
    }
}
