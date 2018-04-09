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
    public class FollowController : ApiController
    {
        private FollowRepository db;
        private ProfileRepository dbProfile;

        public FollowController()
        {
            db = new FollowRepository(new SocialNetworkContext());
            dbProfile = new ProfileRepository(new SocialNetworkContext());
        }

        // GET: api/Follow
        public IEnumerable<Follow> Get()
        {
            return db.GetAll();
        }

        [HttpGet, Route("api/Followers/{id}")]
        public IEnumerable<string> GetFollowers(string id)
        {
            var Ids = new List<string>();
            var x = db.GetFollowers(Guid.Parse(id));
            foreach (var i in db.GetFollowers(Guid.Parse(id)))
                Ids.Add(i.IdFollower.ToString());

            return Ids;
        }

        [HttpGet, Route("api/Following/{id}")]
        public IEnumerable<string> GetFollowing(string id)
        {
            var Ids = new List<string>();
            foreach (var i in db.GetFollowing(Guid.Parse(id)))
                Ids.Add(i.IdFollowed.ToString());

            return Ids;
        }

        // GET: api/Follow/5
        public Follow Get(string id)
        {
            return db.GetById(Guid.Parse(id));
        }

        // POST: api/Follow
        public HttpResponseMessage Post(Follow value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Dados inválidos");
            }

            if(db.FindFollow(value.IdFollower, value.IdFollowed) != null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Já existe uma relação");

            if (db.Save(value))
            {
                if(dbProfile.FollowUp(value.IdFollowed, value.IdFollower))
                    return Request.CreateResponse(HttpStatusCode.OK);

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível incrementar \"seguidores\" ou \"seguindo\"");
            }


            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }

        // DELETE: api/Follow/5
        public HttpResponseMessage Delete(string IdFollowed, string IdFollower)
        {
            var follow = db.FindFollow(Guid.Parse(IdFollower), Guid.Parse(IdFollowed));
            if (follow == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não encontrado");
            }

            if (db.Remove(follow))
            {
                dbProfile.FollowDown(follow.IdFollowed, follow.IdFollower);

                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }
    }
}
