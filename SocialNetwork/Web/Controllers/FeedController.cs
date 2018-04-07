using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using DomainModel.Entities.Profile;
using DomainModel.Entities.Post;

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
        public ActionResult Index()
        {
            string email = Session["session_email"].ToString();
            string id = Session["session_id"].ToString();

            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> resultado = cliente.GetAsync(UrlApi + "api/Profile/" + id);
            Task<Profile> taskProfile = resultado.Result.Content.ReadAsAsync<Profile>();

            Task<HttpResponseMessage> resultPost = cliente.GetAsync(UrlApi + "api/Post");
            Task<List<Post>> taskPost = resultPost.Result.Content.ReadAsAsync<List<Post>>();

            var feedView = new FeedViewModel()
            {
                MyName = taskProfile.Result.Name + " " + taskProfile.Result.LastName,
                MyId = taskProfile.Result.Id,
                Followers = taskProfile.Result.Followers,
                Following = taskProfile.Result.Following,
                MyUrlPhoto = taskProfile.Result.UrlPhoto
            };

            //Pegando todas postagens
            var allPosts = new List<PostViewModel>();
            foreach (var p in taskPost.Result)
            {
                var post = new PostViewModel()
                {
                    DatePosted = p.Date,
                    Mensage = p.Message,
                    Name = p.Name,
                    UrlImage = p.UrlImage,
                    IdPost = p.Id.ToString(),
                    IdProfile = p.IdProfile.ToString()
                };
                allPosts.Add(post);
            }

            feedView.Posts = allPosts;

            return View(feedView);
        }

        // POST: Feed/Create
        [HttpPost]
        public ActionResult PostMensage(FeedViewModel post)
        {
            try
            {
                var Post = new Post()
                {
                    Date = DateTime.Today,
                    IdProfile = Guid.Parse(Session["session_id"].ToString()),
                    Message = post.PostMensage,
                    Name = post.MyName
                    //UrlImage = post.UrlPostImage,
                };

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = client.PostAsJsonAsync("api/Post/", Post);
                if (response.Result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View();
            }
            catch
            {
                return View();
            }
        }
        // POST: Feed/Edit/5
        [HttpPost]
        public ActionResult Edit(PostViewModel value)
        {
            try
            {
                var post = new Post()
                {
                    Id = Guid.Parse(value.IdPost),
                    Message = value.Mensage,
                    Name = value.Name,
                    Date = value.DatePosted
                };
                string id = Session["session_id"].ToString();
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = client.PutAsJsonAsync("api/Post/" + id, post);
                if (response.Result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View();
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
