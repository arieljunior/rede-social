using Data.Repositories;
using DomainModel.Entities.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apis.Controllers
{
    public class PerfilController_old : ApiController
    {
        //ProfileRepository db = new ProfileRepository();
        //// GET: api/Profile
        //public IEnumerable<Profile> Get()
        //{
        //    return db.GetAll();
        //}

        //// GET: api/Profile/5
        //public string Get(string id)
        //{
        //    var newEmail = id + ".com";
        //    return null;//db.GetIdProfile(newEmail);
        //}

        //[HttpGet]
        //[Route("api/MyProfile/{id}")]
        //public Profile GetProfile(string id)
        //{
        //    return db.GetById(id);
        //}

        //// POST: api/Profile
        //public HttpResponseMessage Post(Profile profile)
        //{
        //    if (db.Save(profile))
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK);
        //        }

        //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao salvar");
        //}

        //// PUT: api/Profile/5
        //public HttpResponseMessage Put(string id, Profile profile)
        //{
        //    if (profile != null)
        //    {
        //        if (db.UpDate(id, profile)) return Request.CreateResponse(HttpStatusCode.OK, "Atualizado");
        //    }

        //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        //}

        //// DELETE: api/Profile/5
        //public HttpResponseMessage Delete(string id)
        //{
        //    if (id != null)
        //    {
        //        if (db.Remove(id)) return Request.CreateResponse(HttpStatusCode.OK, "Removido");
        //    }

        //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro");
        //}
}
}
