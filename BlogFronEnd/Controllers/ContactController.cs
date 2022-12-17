using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BlogFronEnd.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Blog.DTO.ContactDTO contact)
        {
            postContact(contact);                        
            return Redirect("/Blog");
        }

        private void postContact(Blog.DTO.ContactDTO contact)
        {
            string Response = "";
            string url = ConfigurationManager.AppSettings["APIUrl"].ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage HttpResponseMessage = null;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var myContent = jss.Serialize(contact);

            var httpContent = new StringContent(myContent, Encoding.UTF8, "application/json");            
            HttpResponseMessage = client.PostAsync("SaveContact", httpContent).Result;

            if (HttpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                Response = HttpResponseMessage.Content.ReadAsStringAsync().Result;
            }            
        }
    }
}