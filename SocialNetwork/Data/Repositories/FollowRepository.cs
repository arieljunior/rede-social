using Data.Context;
using Domain.Interfaces.Repositories;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FollowRepository : IRepository<Follow>
    {
        private SocialNetworkContext _socialNetworkContext;
        private DbSet<Follow> _dbSet;

        public FollowRepository(SocialNetworkContext socialNetworkContext)
        {
            _socialNetworkContext = socialNetworkContext;
            _dbSet = socialNetworkContext.Set<Follow>();
        }

        public IEnumerable<Follow> GetAll()
        {
            return _dbSet;
        }

        public Follow GetById(Guid id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<Follow> GetFollowing(Guid idFollower)
        {
            return _dbSet.Where(c => c.IdFollower == idFollower).ToList();
        }

        public IEnumerable<Follow> GetFollowers(Guid Followed)
        {
            return _dbSet.Where(c => c.IdFollowed == Followed).ToList();
        }

        public Follow Exist(Guid idFollower, Guid idFollowed)
        {
            var y = _dbSet.Where(c => c.IdFollowed == idFollowed && c.IdFollower == idFollower).ToList();
            var x = _dbSet.Where(c => c.IdFollowed == idFollowed && c.IdFollower == idFollower).FirstOrDefault();
            return _dbSet.Where(c => c.IdFollowed == idFollowed && c.IdFollower == idFollower).FirstOrDefault();
        }

        public bool Remove(Follow obj)
        {
            try
            {
                _dbSet.Remove(obj);
                _socialNetworkContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(Follow obj)
        {
            try
            {
                _dbSet.Add(obj);
                _socialNetworkContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpDate(Follow obj)
        {
            throw new NotImplementedException();
        }
    }
}
