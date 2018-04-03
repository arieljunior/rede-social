using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Services
{
    public class ProfileService : IService<Profile>
    {
        private IRepository<Profile> _profileRepository;

        public ProfileService(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public bool Create(Profile obj)
        {
            return _profileRepository.Save(obj);
            
        }

        public IEnumerable<Profile> GetAll()
        {
            return _profileRepository.GetAll();
        }

        public Profile GetById(string id)
        {
            return _profileRepository.GetById(id);
        }

        public bool Delete(string id)
        {
            return _profileRepository.Remove(id);
        }

        public bool UpDate(Profile obj)
        {
            return false;//_profileRepository.UpDate(obj);
        }
    }
}
