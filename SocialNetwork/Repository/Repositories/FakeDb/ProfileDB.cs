using Domain.Models.Profile;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using Domain.Models.Skill;

namespace Repository.Repositories.FakeDb
{
    public class ProfileDB : IRepositoryBase<FriendProfileModel>
    {
        private static List<FriendProfileModel> ProfileData = new List<FriendProfileModel>();

        public bool Save(FriendProfileModel obj)
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

        public List<FriendProfileModel> GetAll()
        {
            return ProfileData;
        }

        public FriendProfileModel GetById(int id)
        {
            foreach (var profile in ProfileData)
            {
                if (id == profile.IdFriend)
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
                if (id == profile.IdFriend)
                {
                    ProfileData.Remove(profile);
                    return true;
                }
            }

            return false;
        }

        public bool Update(FriendProfileModel obj)
        {
            foreach (var profile in ProfileData)
            {
                if (obj.IdFriend == profile.IdFriend)
                {
                    profile.Name = obj.Name;
                    profile.LastName = obj.LastName;
                    profile.City = obj.City;
                    profile.Email = obj.Email;
                    profile.Level = obj.Level;
                    profile.Skills = obj.Skills;
                    return true;
                }
            }

            return false;
        }
    }
}
