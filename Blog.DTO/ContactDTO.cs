using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DTO
{
    public class ContactDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }    
        public string EmailAddress { get; set; }    
        public string ContactNumber { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }  
    }
}
