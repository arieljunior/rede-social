using Data.Context;
using Data.Repositories;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apis.Controllers
{
    public class PostController : ApiController
    {
        private PostRepository db;
        public PostController()
        {
            db = new PostRepository(new SocialNetworkContext());
        }
        // GET: api/Post
        public IEnumerable<Post> Get()
        {
            return db.GetAll();
        }

        // GET: api/Post/5
        public Post Get(string id)
        {
            return db.GetById(Guid.Parse(id));
        }

        // POST: api/Post
        public HttpResponseMessage Post(Post post)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Dados inválidos");
            }

            if (db.Save(post))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }

        // PUT: api/Post/5
        public HttpResponseMessage Put(string id, Post post)
        {
            post.IdProfile = Guid.Parse(id);
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Dados inválidos");
            }

            if (db.UpDate(post))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }

        // DELETE: api/Post/5
        public HttpResponseMessage Delete(string id)
        {
            Post post = db.GetById(Guid.Parse(id));
            if (post == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não encontrado");
            }

            if (db.Remove(post))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }
    }
}
