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
    public class ProfileService : IService<ProfileModel>
    {
        private IRepository<ProfileModel> _profileRepository;

        public ProfileService(IRepository<ProfileModel> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public bool Create(ProfileModel obj)
        {
            return _profileRepository.Save(obj);
            
        }

        public IEnumerable<ProfileModel> GetAll()
        {
            return _profileRepository.GetAll();
        }

        public ProfileModel GetById(string id)
        {
            return _profileRepository.GetById(id);
        }

        public bool Delete(string id)
        {
            return _profileRepository.Remove(id);
        }

        public bool UpDate(ProfileModel obj)
        {
            return _profileRepository.UpDate(obj);
        }
    }
}
