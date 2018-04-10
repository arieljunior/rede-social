using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using DomainModel.Entities;
using Domain.Entities;

namespace Web.Controllers
{
    [Authorize]
    public class FeedController : Controller
    {
        public string UrlApi { get; set; }
        private HttpClient _client;
        public FeedController()
        {
            UrlApi = "http://localhost:51450/";
            _client = new HttpClient();
            _client.BaseAddress = new Uri(UrlApi);
        }
        // GET: Feed
        public ActionResult Index()
        {
            string email = Session["session_email"].ToString();
            string id = Session["session_id"].ToString();
            
            Task<HttpResponseMessage> resultado = _client.GetAsync(UrlApi + "api/Profile/" + id);
            Task<Profile> taskProfile = resultado.Result.Content.ReadAsAsync<Profile>();

            Task<HttpResponseMessage> resultPost = _client.GetAsync(UrlApi + "api/Post");
            Task<List<Post>> taskPost = resultPost.Result.Content.ReadAsAsync<List<Post>>();
            

            var feedView = new FeedViewModel()
            {
                MyName = taskProfile.Result.Name + " " + taskProfile.Result.LastName,
                MyId = taskProfile.Result.Id,
                Followers = taskProfile.Result.Followers,
                Following = taskProfile.Result.Following,
                MyUrlPhoto = taskProfile.Result.UrlPhoto
            };

            //Pegando os seguidores do perfil logado
            Task<HttpResponseMessage> resultFollow = _client.GetAsync(UrlApi + "api/Following/" + taskProfile.Result.Id);
            Task<List<string>> taskFollows = resultFollow.Result.Content.ReadAsAsync<List<string>>();

            //Pegando todos comentários
            Task<HttpResponseMessage> resultComments = _client.GetAsync(UrlApi + "api/CommentsFromPost");
            Task<List<CommentsFromPost>> taskComments = resultComments.Result.Content.ReadAsAsync<List<CommentsFromPost>>();


            var allPosts = new List<PostViewModel>();

            //Pegando todas postagens
            foreach (var post in taskPost.Result)
            {
                //Verifica se o post pertence ao usuário logado
                if (post.IdProfile.ToString().ToUpper().Equals(taskProfile.Result.Id.ToString().ToUpper()))
                {
                    var Post = new PostViewModel()
                    {
                        DatePosted = post.Date,
                        Mensage = post.Message,
                        Name = post.Name,
                        UrlImage = post.UrlImage,
                        IdPost = post.Id.ToString(),
                        IdProfile = post.IdProfile.ToString()
                    };

                    if (taskComments.Result != null && taskComments.Result.Count() >0)
                    {
                        //Pegando todos os comentários do post do usuário que está logado
                        var Comments = new List<CommentsViewModel>();
                        foreach (var comment in taskComments.Result)
                        {
                            if (post.Id == comment.IdPost)
                            {
                                var Comment = new CommentsViewModel()
                                {
                                    Comment = comment.Comment,
                                    Date = comment.DateComment,
                                    Id = comment.Id,
                                    IdProfile = comment.IdProfile,
                                    IdPost = comment.IdPost,
                                    Name = comment.Name
                                };
                                Comments.Add(Comment);
                            }
                        }
                        Post.Comments = Comments.OrderBy(c => c.Date).ToList();
                    }
                    
                    allPosts.Add(Post);
                }
                else
                {
                    foreach (var f in taskFollows.Result)
                    {
                        if (post.IdProfile.ToString().ToUpper().Equals(f.ToUpper()))
                        {
                            var Post = new PostViewModel()
                            {
                                DatePosted = post.Date,
                                Mensage = post.Message,
                                Name = post.Name,
                                UrlImage = post.UrlImage,
                                IdPost = post.Id.ToString(),
                                IdProfile = post.IdProfile.ToString()
                            };

                            if(taskComments.Result != null && taskComments.Result.Count() > 0)
                            {
                                //Pegando todos os comentários do post que o usuário segue
                                var Comments = new List<CommentsViewModel>();
                               
                                foreach (var comment in taskComments.Result)
                                {
                                    if (post.Id == comment.IdPost)
                                    {
                                        var Comment = new CommentsViewModel()
                                        {
                                            Comment = comment.Comment,
                                            Date = comment.DateComment,
                                            Id = comment.Id,
                                            IdProfile = comment.IdProfile,
                                            IdPost = comment.IdPost,
                                            Name = comment.Name
                                        };
                                        Comments.Add(Comment);   
                                    }
                                }
                                Post.Comments = Comments.OrderBy(c => c.Date).ToList();
                            }
                            allPosts.Add(Post);
                        }
                    }
                }
                
            }

            
            feedView.Posts = allPosts.OrderByDescending(o => o.DatePosted).ToList();

            return View(feedView);
        }

        [HttpPost]
        public ActionResult PostComment(string url, string comment, string IdPost, string IdProfile, string Name)
        {
            try
            {
                var Comment = new CommentsFromPost()
                {
                    Comment = comment,
                    IdPost = Guid.Parse(IdPost),
                    IdProfile = Guid.Parse(IdProfile),
                    DateComment = DateTime.Now,
                    Name = Name
                };
                
                
                _client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = _client.PostAsJsonAsync("api/CommentsFromPost/", Comment);

                if (response.Result.IsSuccessStatusCode)
                    return Redirect(url);
                return Redirect(url);
            }
            catch
            {
                return Redirect(url);
            }
        }

        [HttpPost]
        public ActionResult EditComment(string url, string idComment,string idProfile, string idPost, string comment, string name)
        {
            try
            {
                var Comment = new CommentsFromPost()
                {
                    Id = Guid.Parse(idComment),
                    Comment = comment,
                    DateComment = DateTime.Now,
                    IdPost = Guid.Parse(idPost),
                    IdProfile = Guid.Parse(idProfile),
                    Name = name
                };

                _client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = _client.PutAsJsonAsync("api/CommentsFromPost/", Comment);
                if (response.Result.IsSuccessStatusCode)
                    return Redirect(url);
                return Redirect(url);
            }
            catch
            {
                return Redirect(url);
            }
        }
        
        [HttpPost]
        public ActionResult PostMensage(FeedViewModel post)
        {
            try
            {
                var Post = new Post()
                {
                    Date = DateTime.Now,
                    IdProfile = Guid.Parse(Session["session_id"].ToString()),
                    Message = post.PostMensage,
                    Name = post.MyName
                    //UrlImage = post.UrlPostImage,
                };


                _client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = _client.PostAsJsonAsync("api/Post/", Post);
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
        public ActionResult EditPost(PostViewModel value)
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

                _client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> response = _client.PutAsJsonAsync("api/Post/" + id, post);
                if (response.Result.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Feed/Delete/5
        [HttpPost]
        public ActionResult DeletePost(string idPost)
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
