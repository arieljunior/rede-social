using Application.Factory.Interfaces;
using DomainModel.Entities.Post;
using DomainModel.Entities.Profile;
using DomainModel.Entities.Skill;
using Data.Repositories.FakeDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factory.Profile
{
    class ProfileFactory : IFactoryBase<ProfileModel>
    {
        public ProfileModel Build()
        {
            var NewProfile = new ProfileModel();

            NewProfile.IdProfile = new ProfileDB().GetAll().Count() + 1;
            NewProfile.DateCreated = DateTime.Today;
            NewProfile.Level = 0;
            NewProfile.Skills = new List<SkillModel>();
            NewProfile.IdsFollowers = new List<int>();
            NewProfile.IdsFollowing = new List<int>();
            NewProfile.TimeLine = new List<PostModel>();
            NewProfile.IdsCompletedChallenges = new List<int>();
            //imagem qualquer da web para usar como padrão no perfil
            NewProfile.UrlPhoto = "https://cdn.pixabay.com/photo/2012/04/26/19/43/profile-42914_640.png";
            NewProfile.City = "Não informado";
            //Nome, ultimo nome, email e senha não obrigatórios
            
            return NewProfile;
        }
    }
}
