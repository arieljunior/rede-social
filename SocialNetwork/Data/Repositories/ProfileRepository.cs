using Data.Context;
using Domain.Interfaces.Repositories;
using DomainModel.Entities;
using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProfileRepository : IRepository<ProfileModel>
    {
        private SocialNetworkContext _socialNetworkContext;
        private DbSet<ProfileModel> _dbset;

        public ProfileRepository(SocialNetworkContext socialNetworkContext)
        {
            _socialNetworkContext = socialNetworkContext;
            _dbset = socialNetworkContext.Set<ProfileModel>();
        }
        public IEnumerable<ProfileModel> GetAll()
        {
            return null;
        }

        public ProfileModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(ProfileModel profile)
        {
            _dbset.Add(profile);
            _socialNetworkContext.SaveChanges();

            return true;
        }

        public bool UpDate(ProfileModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
