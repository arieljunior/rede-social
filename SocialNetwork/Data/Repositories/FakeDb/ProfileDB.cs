using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using DomainModel.Entities.Skill;
using Domain.Interfaces.Repositories;

namespace Data.Repositories.FakeDb
{
    public class ProfileDB : IRepository<ProfileModel>
    {
        private static List<ProfileModel> ProfileData = new List<ProfileModel>();

        public bool Save(ProfileModel obj)
        {
            try
            {
                ProfileData.Add(obj);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        public IEnumerable<ProfileModel> GetAll()
        {
            return ProfileData;
        }

        public ProfileModel GetById(int id)
        {
            foreach (var profile in ProfileData)
            {
                if (id == profile.IdProfile)
                {
                    return profile;
                }
            }

            return null;
        }

        public bool Remove(int id)
        {
            foreach (var profile in ProfileData)
            {
                if (id == profile.IdProfile)
                {
                    ProfileData.Remove(profile);
                    return true;
                }
            }

            return false;
        }

        public bool UpDate(ProfileModel obj)
        {
            foreach (var profile in ProfileData)
            {
                if (obj.IdProfile == profile.IdProfile)
                {
                    profile.Name = obj.Name;
                    profile.LastName = obj.LastName;
                    profile.City = obj.City;
                    profile.Email = obj.Email;
                    profile.Password = obj.Password;
                    profile.Level = obj.Level;
                    profile.Skills = obj.Skills;
                    return true;
                }
            }

            return false;
        }
    }
}
