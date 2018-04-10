using Data.Context;
using Data.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apis.Controllers
{
    public class CommentsFromPostController : ApiController
    {
        private CommentsFromPostsRepository db;
        public CommentsFromPostController()
        {
            db = new CommentsFromPostsRepository(new SocialNetworkContext());
        }

        // GET: api/CommentsFromPost
        public IEnumerable<CommentsFromPost> Get()
        {
            return db.GetAll();
        }

        // GET: api/CommentsFromPost/5
        public IEnumerable<CommentsFromPost> Get(string id)
        {
            return db.GetCommentsFromPost(Guid.Parse(id));
        }

        // POST: api/CommentsFromPost
        public HttpResponseMessage Post(CommentsFromPost value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Dados inválidos");
            }

            if (db.Save(value))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }

        // PUT: api/CommentsFromPost/5
        public HttpResponseMessage Put(CommentsFromPost value)
        {
            //value.Id = Guid.Parse(id);
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Dados inválidos");
            }

            if (db.UpDate(value))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }

        // DELETE: api/CommentsFromPost/5
        public HttpResponseMessage Delete(string id)
        {
            CommentsFromPost comment = db.GetById(Guid.Parse(id));
            if (comment == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não encontrado");
            }

            if (db.Remove(comment))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }
    }
}
