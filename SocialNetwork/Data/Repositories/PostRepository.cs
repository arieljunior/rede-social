using Data.Context;
using Domain.Interfaces.Repositories;
using DomainModel.Entities.Post;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private SocialNetworkContext _socialNetworkContext;
        private DbSet<Post> _dbSet;

        public PostRepository(SocialNetworkContext socialNetworkContext)
        {
            _socialNetworkContext = socialNetworkContext;
            _dbSet = _socialNetworkContext.Set<Post>();
        }

        public IEnumerable<Post> GetAll()
        {
            return _dbSet;
        }

        public Post GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public bool Remove(Post obj)
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

        public bool Save(Post obj)
        {
            try
            {
                _dbSet.Add(obj);
                _socialNetworkContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpDate(Post obj)
        {
            try
            {
                _socialNetworkContext.Entry(obj).State = EntityState.Modified;
                _socialNetworkContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
