using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
            UrlApi = "http://localhost:51450/api/Profile/";
        }
        // GET: Profile
        public ActionResult Index()
        {
            //var Books = new List<ProfileViewModel>();
            //var requisicaoWeb = WebRequest.CreateHttp(UrlApi);
            //requisicaoWeb.Method = "GET";

            //using (var resposta = requisicaoWeb.GetResponse())
            //{
            //    var streamDados = resposta.GetResponseStream();
            //    StreamReader reader = new StreamReader(streamDados);
            //    object objResponse = reader.ReadToEnd();
            //    var booksData = JsonConvert.DeserializeObject<List<Book>>(objResponse.ToString());
            //    foreach (var b in booksData)
            //    {
            //        var book = new BookViewModel()
            //        {
            //            Id = b.BookId,
            //            Title = b.Title,
            //            Isbn = b.Isbn,
            //            Year = b.Year
            //        };
            //        Books.Add(book);

            //    }
            //    streamDados.Close();
            //    resposta.Close();
            //}

            return View();
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
                string City = data.City != null || !data.City.Equals("") ? data.City : "NÃO INFORMADO";
                string Photo = data.UrlPhoto != null || !data.UrlPhoto.Equals("") ? data.UrlPhoto : " ";
                string id = Session["session_id"].ToString().Replace("\"", "");
                string dadosPOST = $"Name={data.Name}&LastName={data.LastName}&id={id}&Followers=0&Following=0" +
                    $"&City={City}&UrlPhoto{Photo}";
                var dados = Encoding.UTF8.GetBytes(dadosPOST);
                var requisicaoWeb = WebRequest.CreateHttp(UrlApi);
                requisicaoWeb.Method = "POST";
                requisicaoWeb.ContentType = "application/x-www-form-urlencoded";
                requisicaoWeb.ContentLength = dados.Length;

                using (var stream = requisicaoWeb.GetRequestStream())
                {
                    stream.Write(dados, 0, dados.Length);
                    stream.Close();
                }

                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    string objResponse = reader.ReadToEnd();
                    streamDados.Close();
                    resposta.Close();
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
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
