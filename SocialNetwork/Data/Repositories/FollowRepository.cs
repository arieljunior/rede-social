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
        public Follow FindFollow(Guid idProfileFollower, Guid idProfileFollowed)
        {
            try
            {
                var follow = _dbSet.Where(f => f.IdFollower == idProfileFollower && f.IdFollowed == idProfileFollowed).First();
                return follow;
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<Follow> GetFollowing(Guid idFollower)
        {
            return _dbSet.Where(c => c.IdFollower == idFollower).ToList();
        }

        public IEnumerable<Follow> GetFollowers(Guid Followed)
        {
            return _dbSet.Where(c => c.IdFollowed == Followed).ToList();
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
