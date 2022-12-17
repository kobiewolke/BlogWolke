using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DTO
{
    public class ArticleDTO
    {
        public int ID { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string ImageURL { get;set; }
        public DateTime Created { get; set; }
    }
}
