using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FollowController : Controller
    {
        private string UrlApi;

        public FollowController()
        {
            UrlApi = "http://localhost:51450/";
        }

        [HttpPost]
        public ActionResult FollowUp(string IdFollower, string IdFollowed, string Url)
        {
            try
            {
                var follow = new Follow()
                {
                    IdFollowed = Guid.Parse(IdFollowed),
                    IdFollower = Guid.Parse(IdFollower)
                };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = client.PostAsJsonAsync("api/Follow/", follow);
                if (response.Result.IsSuccessStatusCode)
                    return Redirect(Url);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Follow/Delete/5
        [HttpPost]
        public ActionResult UnFollow(string IdFollower, string IdFollowed, string Url)
        {
            try
            {
                var follow = new Follow()
                {
                    IdFollowed = Guid.Parse(IdFollowed),
                    IdFollower = Guid.Parse(IdFollower)
                };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(UrlApi);
                //client.DefaultRequestHeaders.Accept.Add(
                //    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = client.DeleteAsync($"api/Follow?IdFollowed={IdFollowed}&IdFollower={IdFollower}");
                if (response.Result.IsSuccessStatusCode)
                    return Redirect(Url);

                return Redirect(Url);
            }
            catch
            {
                return View();
            }
        }
    }
}
