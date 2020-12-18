using ContactTaskDomain.DomainServices.Interfaces;
using ContactTaskDomain.Entities;
using ContactTaskDomain.Repositories;
using ContactTaskDomain.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;

namespace ContactTaskDomain.DomainServices
{
    public class ContactDomainService : IContactDomainService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IContactRepository contactRepository;

        public ContactDomainService(IUnitOfWork unitOfWork, IContactRepository contactRepository)
        {
            this.unitOfWork = unitOfWork;
            this.contactRepository = contactRepository;
        }

        public void AddContact(Contact contact)
        {
            unitOfWork.Entry<Contact>(contact).State = EntityState.Added;
            unitOfWork.SaveChanges();
        }

        public ICollection<Contact> GetAllContacts()
        {
            return contactRepository.GetCollection();
        }

        public Contact GetContactById(int id)
        {
            return contactRepository.Get(id);   
        }

        public void EditContact(Contact contact)
        {
            unitOfWork.Entry<Contact>(contact).State = EntityState.Modified;
            unitOfWork.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            unitOfWork.Entry<Contact>(contact).State = EntityState.Deleted;
            unitOfWork.SaveChanges();
        }
    }
}
