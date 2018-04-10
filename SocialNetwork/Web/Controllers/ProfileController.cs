using DomainModel.Entities;
using StorageService;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
                Following = Profile.Following,
                Email = Profile.Email
            };

            return View(ViewProfile);
        }

        public ActionResult DetailsProfile(string id)
        {
            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> resultado = cliente.GetAsync(UrlApi + "api/Profile/" + id);

            Task<Profile> taskProfile = resultado.Result.Content.ReadAsAsync<Profile>();
            Profile Profile = taskProfile.Result;
            var ViewProfile = new ProfileViewModel()
            {
                City = Profile.City,
                LastName = Profile.LastName,
                Name = Profile.Name,
                UrlPhoto = Profile.UrlPhoto,
                Id = Profile.Id,
                Followers = Profile.Followers,
                Following = Profile.Following,
                Email = Profile.Email,
            };

            Task<HttpResponseMessage> ResultFollowing = cliente.GetAsync(UrlApi + "api/Following/" + Session["session_id"].ToString());
            Task<List<string>> taskFollowing = ResultFollowing.Result.Content.ReadAsAsync<List<string>>();

            foreach(var f in taskFollowing.Result)
            {
                if (f.ToString().Equals(ViewProfile.Id.ToString()))
                    ViewProfile.IsFollowed = true;
            }

            return View(ViewProfile);
        }

        // GET: Profile/Details/5
        public ActionResult AllProfiles()
        {
            HttpClient cliente = new HttpClient();

            //Pega todos os perfis cadastrados no banco
            Task<HttpResponseMessage> resultado = cliente.GetAsync(UrlApi + "api/Profile/");
            Task<List<Profile>> taskProfiles = resultado.Result.Content.ReadAsAsync<List<Profile>>();
            var Profiles = new List<ProfileViewModel>();

            foreach (var p in taskProfiles.Result)
            {
                if (!p.Id.ToString().Equals(Session["session_id"].ToString()))
                {
                    var profile = new ProfileViewModel()
                    {
                        Id = p.Id,
                        City = p.City,
                        Email = p.Email,
                        Followers = p.Followers,
                        Following = p.Following,
                        LastName = p.LastName,
                        Name = p.Name,
                        UrlPhoto = p.UrlPhoto
                    };

                    Profiles.Add(profile);
                }
            }

            //Verifica quais desses perfis o usuário logado segue
            Task<HttpResponseMessage> ResultFollowwing = cliente.GetAsync(UrlApi + "api/Following/" + Session["session_id"].ToString());
            Task<List<string>> taskFollowing = ResultFollowwing.Result.Content.ReadAsAsync<List<string>>();

            foreach (var f in taskFollowing.Result)
            {
                foreach (var p in Profiles)
                    if (f.Equals(p.Id.ToString()))
                        p.IsFollowed = true;
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
                //BlobService blob = new BlobService();
                //string url = blob.UploadImage("imagesProfile",data.UploadFoto.FileName, data.UploadFoto.InputStream,
                //    data.UploadFoto.ContentType);

                //data.Id = Guid.Parse(Session["session_id"].ToString().Replace("\"", "").Replace("\\", ""));
                //data.Email = Session["session_email"].ToString();

                var profile = new Profile()
                {
                    City = data.City,
                    Email = Session["session_email"].ToString(),
                    Followers = 0,
                    Following = 0,
                    Name = data.Name,
                    LastName = data.LastName,
                    Id = Guid.Parse(Session["session_id"].ToString()),
                    UrlPhoto = "http://www.personalbrandingblog.com/wp-content/uploads/2017/08/blank-profile-picture-973460_640-300x300.png"
                };

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = client.PostAsJsonAsync("api/Profile/", profile);
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

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase data)
        {
            try
            {
                BlobService blob = new BlobService();
                string url = blob.UploadImage("LeagueBookImagesProfile", Guid.NewGuid().ToString(), data.InputStream,
                    data.ContentType);


                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
