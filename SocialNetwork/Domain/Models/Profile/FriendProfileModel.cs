using Domain.Models.Skill;
using System.Collections.Generic;

namespace Domain.Models.Profile
{
    public class FriendProfileModel : ProfileBaseModel
    {
        public int IdFriend { get; set; }
        public int Level { get; set; }
        public List<SkillModel> Skills { get; set; }
        public bool SendChallenge { get; set; }
    }
}
