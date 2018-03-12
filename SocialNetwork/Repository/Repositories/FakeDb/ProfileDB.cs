using Domain.Models.Profile;
using Repository.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.FakeDb
{
    public class ProfileDB : IRepositoryBase<FriendProfileModel>
    {
        private static List<FriendProfileModel> ProfileData = new List<FriendProfileModel>();

        public bool Add(FriendProfileModel obj)
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
                    profile.SendChallenge = obj.SendChallenge;
                    return true;
                }
            }

            return false;
        }

        public bool LevelUp(int idProfile, int amountToUpload)
        {
            try
            {
                var FriendLevelUp = GetById(idProfile);
                FriendLevelUp.Level += amountToUpload;

                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        public bool ChangeChoiceOfChallenge(int idProfile)
        {
            try
            {
                var MyProfile = GetById(idProfile);

                if (MyProfile.SendChallenge)
                {
                    MyProfile.SendChallenge = false;
                } else
                {
                    MyProfile.SendChallenge = true;
                }

                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}
