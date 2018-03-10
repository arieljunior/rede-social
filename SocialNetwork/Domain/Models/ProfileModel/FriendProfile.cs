using Domain.Models.SkillModel;
using System.Collections.Generic;

namespace Domain.Models.ProfileModel
{
    public class AmigoPerfil : ProfileBase
    {
        public int IdFriend { get; set; }
        public int Level { get; set; }
        public List<Skill> Skills { get; set; }
        public bool SendChallenge { get; set; }
    }
}
