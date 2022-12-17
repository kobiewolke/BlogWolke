using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL
{
    public class ContactDAL
    {
        private Blog.Entities.BlogEntities _blogEntities;

        /// <summary>
        /// Method to save a contact, it will update the contact if it is in the DB otherwise will create a new one
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>The ID of the contact being saved</returns>
        public int SaveContact(Blog.DTO.ContactDTO contact)
        {
            try
            {
                using (_blogEntities = new Blog.Entities.BlogEntities())
                {
                    var query = from a in _blogEntities.Contacts
                                where a.ID == contact.ID
                                select a;

                    if (query.Count() > 0)
                    {
                        Entities.Contact contactToUpdate = query.First();
                        contactToUpdate.ID = contact.ID;
                        contactToUpdate.Name = contact.Name;
                        contactToUpdate.EmailAddress = contact.EmailAddress;
                        contactToUpdate.Message = contact.Message;
                        contactToUpdate.ContactNumber = contact.ContactNumber;
                        contactToUpdate.CreatedDate = DateTime.Now;
                        _blogEntities.SaveChangesAsync();
                    }
                    else
                    {
                        Entities.Contact newContact = new Entities.Contact();                        
                        newContact.Name = contact.Name;
                        newContact.EmailAddress = contact.EmailAddress;
                        newContact.Message = contact.Message;
                        newContact.ContactNumber = contact.ContactNumber;
                        newContact.CreatedDate = DateTime.Now;
                        _blogEntities.Contacts.Add(newContact);
                        _blogEntities.SaveChanges();
                        contact.ID = newContact.ID;
                    }
                }
                return contact.ID;
            }
            catch
            {
                throw;
            }
        }
    }
}
