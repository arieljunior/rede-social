using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using DomainModel.Entities.Profile;

namespace Web.Controllers
{
    [Authorize]
    public class FeedController : Controller
    {
        public string UrlApi { get; set; }
        public FeedController()
        {
            UrlApi = "http://localhost:51450/";
        }
        // GET: Feed
        public ActionResult FeedIndex()
        {
            string email = Session["session_email"].ToString();
            string id = Session["session_id"].ToString();

            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> resultado = cliente.GetAsync(UrlApi + "api/Profile/" + id);

            Task<Profile> taskProfile = resultado.Result.Content.ReadAsAsync<Profile>();

            var feedView = new FeedViewModel()
            {
                MyName = taskProfile.Result.Name + " " + taskProfile.Result.LastName,
                MyId = taskProfile.Result.Id,
                Followers = taskProfile.Result.Followers,
                Following = taskProfile.Result.Following,
                MyUrlPhoto = taskProfile.Result.UrlPhoto
            };


            return View(feedView);
        }

        // POST: Feed/Create
        [HttpPost]
        public ActionResult PostMensage(FeedViewModel post)
        {
            try
            {
                

                return RedirectToAction("FeedIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Feed/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Feed/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Feed/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Feed/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
