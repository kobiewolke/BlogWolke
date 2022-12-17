using Blog.DTO;
using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public class ArticleDAL
    {
        private Blog.Entities.BlogEntities _blogEntities;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blog.DTO.ArticleDTO> ListArticles()
        {
            List<ArticleDTO> articles = null;
            try
            {
                using (Blog.Entities.BlogEntities db = new BlogEntities())
                {
                    var query = from a in db.Articles
                                orderby a.CreatedDate descending
                                select a;

                    if (query.Count() > 0)
                    {
                        articles = new List<ArticleDTO>();

                        foreach (var article in query)
                        {
                            articles.Add(new ArticleDTO
                            {
                                Body = article.Body,
                                Created = article.CreatedDate,
                                Description = article.Description,
                                ID = article.ID,
                                ImageURL = article.ImageURL,
                                Title = article.Title
                            });
                        }
                    }
                    return articles;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public ArticleDTO GetArticle(int articleId)
        {
            try
            {
                ArticleDTO articleDTO = null;
                using (_blogEntities = new BlogEntities())
                {
                    var query = from a in _blogEntities.Articles
                                where a.ID == articleId
                                select a;

                    if (query.Count() > 0)
                    {
                        var item = query.First();
                        articleDTO = new ArticleDTO()
                        {
                            ID = item.ID,
                            Title = item.Title,
                            Body = item.Body,
                            Created = item.CreatedDate,
                            Description = item.Description,
                            ImageURL = item.ImageURL
                        };
                    }
                }
                return articleDTO;
            }
            catch
            {
                throw;
            }
        }
    }
}
