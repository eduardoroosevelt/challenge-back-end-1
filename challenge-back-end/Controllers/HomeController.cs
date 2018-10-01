using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using challenge_back_end.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace challenge_back_end.Views.Home
{
    public class HomeController : Controller
    {
        
        HttpClient client = new HttpClient();
        string porta = "11551";


        // GET: Home
        public async Task<ActionResult> Index()
        {
            client.BaseAddress = new Uri("http://localhost:"+porta);
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/ApiPosts/GetHomePage").Result;

            var posts = response.Content.ReadAsAsync<IEnumerable<Posts>>().Result;
            return View(posts);
        }

        // GET: Home/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client.BaseAddress = new Uri("http://localhost:" + porta);
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/ApiPosts/GetDeitals/" + id).Result;

            var posts = response.Content.ReadAsAsync<Posts>().Result;

            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client.BaseAddress = new Uri("http://localhost:" + porta);
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/ApiPosts/Get/" + id).Result;

            var posts = response.Content.ReadAsAsync<Posts>().Result;
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }


        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Codigo,Titulo,Descricao,Conteudo,qtdViews,qtdLikes,PorcentagemLike,PorcentagemView")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                 new KeyValuePair<string, string>("Id",Convert.ToString(posts.Id)),
                 new KeyValuePair<string, string>("Codigo",posts.Codigo),
                 new KeyValuePair<string, string>("Titulo",posts.Titulo),
                 new KeyValuePair<string, string>("Descricao",posts.Descricao),
                 new KeyValuePair<string, string>("Conteudo",posts.Conteudo)
                };

                string url = "http://localhost:" + porta + "/api/ApiPosts/Update/";
                HttpContent q = new FormUrlEncodedContent(queries);
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PostAsync(url, q))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            HttpContentHeaders headers = content.Headers;
                        }

                    }
                }
                return RedirectToAction("Index");
            }
            return View(posts);
        }


        
        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Codigo,Titulo,Descricao,Conteudo")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                {
                
                 new KeyValuePair<string, string>("Codigo",posts.Codigo),
                 new KeyValuePair<string, string>("Titulo",posts.Titulo),
                 new KeyValuePair<string, string>("Descricao",posts.Descricao),
                 new KeyValuePair<string, string>("Conteudo",posts.Conteudo)
                };

                string url = "http://localhost:" + porta + "/api/ApiPosts/Post/";
                HttpContent q = new FormUrlEncodedContent(queries);
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PostAsync(url, q))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();
                            HttpContentHeaders headers = content.Headers;
                        }

                    }
                }
            }

            return View(posts);
        }

        
     
        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client.BaseAddress = new Uri("http://localhost:" + porta);
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/ApiPosts/Get/" + id).Result;

            var posts = response.Content.ReadAsAsync<Posts>().Result;
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(posts);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                 new KeyValuePair<string, string>("Id",Convert.ToString(id))
            };

            string url = "http://localhost:" + porta + "/api/ApiPosts/Delete/";
            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url, q))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;
                    }

                }
            }


            return RedirectToAction("Index");
        }

             
        // GET: Home/Details/5
        public async Task<ActionResult> Like(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id",Convert.ToString(id))
            };

            string url = "http://localhost:" + porta+ "/api/ApiPosts/IncrementarLike/";
            HttpContent q = new FormUrlEncodedContent(queries);
            using(HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(url,q))
                {
                    using(HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;
                    }

                }
            }
          
            return RedirectToAction("Index");
        }

        // GET: Home
        public async Task<ActionResult> TodosPosts()
        {
            client.BaseAddress = new Uri("http://localhost:" + porta);
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/ApiPosts/Get").Result;

            var posts = response.Content.ReadAsAsync<IEnumerable<Posts>>().Result;

            return View(posts);
        }

        
    }
}
