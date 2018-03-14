using Domain.Models.Skill;
using System.Collections.Generic;

namespace Domain.Models.Profile
{
    public class ProfileModel : ProfileBaseModel
    {
        public int IdProfile { get; set; }
        public int Level { get; set; }
        public List<SkillModel> Skills { get; set; }
        //lista de ids dos desafios completados. Os desafios seram Post com tipo (type) true
        public List<int> IdsCompletedChallenges { get; set; }
        //lista de ids dos seguidores
        public  List<int> IdsFollowers { get; set; }
        //Lista de ids das pessoas que estão seguindo
        public List<int> IdsFollowing { get; set; }
    }
}
