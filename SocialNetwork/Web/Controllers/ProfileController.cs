using DomainModel.Entities.Profile;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
            string id = Session["session_id"].ToString().Replace("\"","").Replace("\\","");
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
                Email = Session["session_email"].ToString()
            };

            return View(ViewProfile);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
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
