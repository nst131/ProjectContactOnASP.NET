using ContactTaskDomain.Entities;
using System.Collections.Generic;

namespace ContactTaskDomain.DomainServices.Interfaces
{
    public interface IContactDomainService : IBaseDomainService
    {
        void AddContact(Contact contact);
        void DeleteContact(Contact contact);
        void EditContact(Contact contact);
        ICollection<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}
