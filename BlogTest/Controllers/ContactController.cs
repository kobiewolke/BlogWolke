using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogTest.Controllers
{
    public class ContactController : ApiController
    {
        [HttpPost]
        [Route("api/SaveContact")]
        public IHttpActionResult SaveContact(Blog.DTO.ContactDTO contact)
        {
            try
            {
                Blog.DAL.ContactDAL contactDAL = new Blog.DAL.ContactDAL(); 
                Blog.DTO.ContactDTO contactDTO = new Blog.DTO.ContactDTO();                
                
                return Ok(contactDAL.SaveContact(contact));
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message});
            }
        }
    }
}
