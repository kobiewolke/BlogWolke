using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogTest.Controllers
{
    public class BlogController : ApiController
    {
        [HttpGet]
        [Route("api/Articles")]
        public IHttpActionResult Articles()
        {
            try
            {
                Blog.DAL.ArticleDAL articleDAL = new Blog.DAL.ArticleDAL();
                return Json(articleDAL.ListArticles());                
            }
            catch (Exception ex)
            {
                return Ok(new { message = "Exception: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("api/DisplayArticle")]
        public IHttpActionResult DisplayArticle(int ID)
        {
            try
            {
                Blog.DAL.ArticleDAL articleDAL = new Blog.DAL.ArticleDAL();
                return Json(articleDAL.GetArticle(ID));
            }
            catch (Exception ex)
            {
                return Ok(new { message = "Exception: " + ex.Message });
            }
        }
    }
}
