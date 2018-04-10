using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CommentsFromPostsRepository : IRepository<CommentsFromPost>
    {
        private SocialNetworkContext _socialNetworkContext;
        private DbSet<CommentsFromPost> _dbSet;

        public CommentsFromPostsRepository(SocialNetworkContext socialNetworkContext)
        {
            _socialNetworkContext = socialNetworkContext;
            _dbSet = socialNetworkContext.Set<CommentsFromPost>();
        }

        public IEnumerable<CommentsFromPost> GetAll()
        {
            return _dbSet;
        }

        public CommentsFromPost GetById(Guid idComment)
        {
            return _dbSet.Find(idComment);
        }

        public IEnumerable<CommentsFromPost> GetCommentsFromPost(Guid idPost)
        {
            try
            {
                var value = _dbSet.Where(c => c.IdPost == idPost).ToList();
                return value;
            }
            catch
            {
                return null;
            }
        }

        public bool Remove(CommentsFromPost obj)
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

        public bool Save(CommentsFromPost obj)
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

        public bool UpDate(CommentsFromPost obj)
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
