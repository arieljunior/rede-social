using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class FeedController : Controller
    {
        [Authorize]
        // GET: Feed
        public ActionResult FeedIndex()
        {
            string email = Session["session_email"].ToString();
            string id = Session["session_id"].ToString();
            var myFeed = new FeedViewModel()
            {
                MyId = Guid.Parse("b0e63dca-7867-4664-a7ab-9770491ed3c0"),
                MyName = "Ariel Junior",
                MyElo = "Platina IV",
                MyHonors = "Honra 5",
                Followers = 4,
                Following = 5,
                Posts = new List<PostViewModel>()
                {
                    new PostViewModel()
                    {
                        Name ="Amigo",
                        Mensage ="Mensagem postada teste",
                        Elo ="Ouro III",
                        UrlImage = "https://art-of-lol.com/wp-content/uploads/2015/12/Karthus-League-Of-Legends-Fan-Art-1-360x400.jpg",
                        Like = 2
                    },
                    new PostViewModel()
                    {
                        Name ="Amigo2",
                        Mensage ="Mensagem postada teste2",
                        Elo ="Diamante V",
                        UrlImage = "https://br.leagueoflegends.com/sites/default/files/styles/scale_xlarge/public/upload/sion_hextech_splash_final_1.jpg?itok=7kioKbyO",
                        Like = 4
                    }
                }
            };

            
            return View(myFeed);
        }

        // GET: Feed/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Feed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feed/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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
