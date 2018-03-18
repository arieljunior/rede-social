using DomainModel.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;

namespace Data.Repositories.FakeDb
{
    public class PostDb : IRepository<PostModel>
    {
        private static List<PostModel> PostData = new List<PostModel>();

        public bool Save(PostModel obj)
        {

            try
            {
                PostData.Add(obj);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        public IEnumerable<PostModel> GetAll()
        {
            return PostData;
        }

        public PostModel GetById(int id)
        {
            foreach(var post in PostData)
            {
                if (id == post.IdPost)
                {
                    return post;
                }
            }

            return null;
        }

        public bool Remove(int id)
        {
            foreach (var post in PostData)
            {
                if (id == post.IdPost)
                {
                    PostData.Remove(post);
                    return true;
                }
            }

            return false;
        }

        public bool UpDate(PostModel obj)
        {
            foreach (var post in PostData)
            {
                if (obj.IdPost == post.IdPost)
                {
                    post.Message = obj.Message;
                    post.UrlImage = obj.UrlImage;
                    return true;
                }
            }

            return false;
        }
    }
}
