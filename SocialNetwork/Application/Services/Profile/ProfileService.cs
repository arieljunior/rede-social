using Application.Factory.Profile;
using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Profile
{
    public class ProfileService
    {
        private new ProfileFactory Factory = new ProfileFactory();
        //private new ProfileDB DataBase = new ProfileDB();

        //public bool CreateProfile(Profile profile)
        //{
        //    var NewProfile = Factory.Build();

        //    NewProfile.Name = profile.Name.ToLower();
        //    NewProfile.LastName = profile.LastName.ToLower();
        //    NewProfile.Email = profile.Email;
        //    NewProfile.Password = profile.Password;
        //    NewProfile.City = profile.City != null && profile.City != "" ? profile.City : NewProfile.City;
        //    NewProfile.UrlPhoto = profile.UrlPhoto != null && profile.UrlPhoto != "" ? profile.UrlPhoto : NewProfile.UrlPhoto;

        //    return DataBase.Save(NewProfile);
        //}

    }
}
