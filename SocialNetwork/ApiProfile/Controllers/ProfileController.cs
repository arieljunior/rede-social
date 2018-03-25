using Data.Repositories;
using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProfile.Controllers
{
    public class ProfileController : ApiController
    {
        ProfileRepository db = new ProfileRepository();
        // GET: api/Profile
        public IEnumerable<ProfileModel> Get()
        {
            return db.GetAll();
        }

        // GET: api/Profile/5
        public ProfileModel Get(string id)
        {
            return db.GetById(id);
        }

        // POST: api/Profile
        public HttpResponseMessage Post(ProfileModel value)
        {
            var profile = new ProfileModel();
            profile = value;
            if (profile != null)
            {
                //tratar os dados com as conf default antes de salvar
                if (db.Save(profile))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Salvo");
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao salvar");
        }

        // PUT: api/Profile/5
        public HttpResponseMessage Put(string id, ProfileModel profile)
        {
            if(profile != null)
            {
                if (db.UpDate(id, profile)) return Request.CreateResponse(HttpStatusCode.OK, "Atualizado");
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }

        // DELETE: api/Profile/5
        public HttpResponseMessage Delete(string id)
        {
            if(id != null)
            {
                if (db.Remove(id)) return Request.CreateResponse(HttpStatusCode.OK, "Removido");
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        }
    }
}
