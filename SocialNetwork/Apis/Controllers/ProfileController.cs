using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Data.Context;
using Data.Repositories;
using DomainModel.Entities.Profile;

namespace Apis.Controllers
{
    public class ProfileController : ApiController
    {
        private ProfileRepository db;

        public ProfileController()
        {
            db = new ProfileRepository(new SocialNetworkContext());
        }

        // GET: api/Profile
        public IEnumerable<Profile> GetProfiles()
        {
            return db.GetAll();
        }
        
        [HttpGet, Route("api/ProfileGetId/{id}")]
        public string GetId(string id)
        {//o id é email
            string Email = id.Replace("!", ".");//HttpUtility.UrlDecode(id);

            return db.GetIdByEmail(Email);
        }

        // GET: api/Profile/5
        [ResponseType(typeof(Profile))]
        public Profile GetProfile(Guid id)
        {
            Profile Profile = db.GetById(id);
            if (Profile == null)
            {
                return null;
            }

            return Profile;
        }

        // PUT: api/Profile/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage PutProfile(Guid id, Profile Profile)
        {
            Profile.Id = id;
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Dados inválidos");
            }

            if(db.UpDate(Profile))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");

        }

        // POST: api/Profile
        [ResponseType(typeof(Profile))]
        public HttpResponseMessage PostProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
            }

            if (db.Save(profile))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }

        // DELETE: api/Profile/5
        [ResponseType(typeof(Profile))]
        public HttpResponseMessage DeleteProfile(Guid id)
        {
            Profile Profile = db.GetById(id);
            if (Profile == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não encontrado");
            }

            if (db.Remove(Profile))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }
    }
}