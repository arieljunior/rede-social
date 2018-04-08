using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private string UrlApi { get; set; }
        public ProfileController()
        {
            UrlApi = "http://localhost:51450/";
        }
        // GET: Profile
        public ActionResult Index()
        {
            string id = Session["session_id"].ToString();
            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> resultado = cliente.GetAsync(UrlApi + "api/Profile/" + id);

            Task<Profile> taskProfile = resultado.Result.Content.ReadAsAsync<Profile>();
            Profile Profile = taskProfile.Result;

            var ViewProfile = new ProfileViewModel() {
                City = Profile.City,
                LastName = Profile.LastName,
                Name = Profile.Name,
                UrlPhoto = Profile.UrlPhoto,
                Id = Profile.Id,
                Followers = Profile.Followers,
                Following = Profile.Following
                //Email = Session["session_email"].ToString()
            };

            return View(ViewProfile);
        }

        // GET: Profile/Details/5
        public ActionResult AllProfiles()
        {
            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> resultado = cliente.GetAsync(UrlApi + "api/Profile/");
            Task<List<Profile>> taskProfiles = resultado.Result.Content.ReadAsAsync<List<Profile>>();
            var Profiles = new List<ProfileViewModel>();

            foreach(var p in taskProfiles.Result)
            {
                var profile = new ProfileViewModel()
                {
                    Id = p.Id,
                    City = p.City,
                    Email = Session["session_email"].ToString(),
                    Followers = p.Followers,
                    Following = p.Following,
                    LastName = p.LastName,
                    Name = p.Name,
                    UrlPhoto = p.UrlPhoto
                };

                Profiles.Add(profile);
            }

            return View(Profiles);
        }

        // GET: Profile/Create
        public ActionResult StepTwoCreate()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult StepTwoCreate(ProfileViewModel data)
        {
            try
            {
                data.Id = Guid.Parse(Session["session_id"].ToString().Replace("\"", "").Replace("\\", ""));

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = client.PostAsJsonAsync("api/Profile/", data);
                if (response.Result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(ProfileViewModel profile)
        {
            try
            {
                var Profile = new Profile()
                {
                    City = profile.City,
                    Name = profile.Name,
                    LastName = profile.LastName,
                    UrlPhoto = profile.UrlPhoto,
                    Following =  profile.Following,
                    Followers = profile.Followers
                };

                string id = Session["session_id"].ToString();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = client.PutAsJsonAsync("api/Profile/" + id, Profile);
                if (response.Result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
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
