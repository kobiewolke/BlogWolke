using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BlogFronEnd.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            string url = ConfigurationManager.AppSettings["APIUrl"].ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("Articles");
            response.Wait();

            var result = response.Result;
            if(result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                var articles = JsonConvert.DeserializeObject<List<Blog.DTO.ArticleDTO>>(readTask.Result);  
                return View(articles);
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult ReadArticle(int id)
        {
            string url = ConfigurationManager.AppSettings["APIUrl"].ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("DisplayArticle?ID=" + id);
            response.Wait();

            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                var article = JsonConvert.DeserializeObject<Blog.DTO.ArticleDTO>(readTask.Result);
                return View(article);
            }
            else
                return View();
        }
    }
}