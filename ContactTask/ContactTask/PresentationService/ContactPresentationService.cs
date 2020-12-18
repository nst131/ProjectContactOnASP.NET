using AutoMapper;
using ContactTask.PresentationService.Interfaces;
using ContactTask.ViewModels;
using ContactTaskDomain.DomainServices.Interfaces;
using ContactTaskDomain.Entities;
using System.Collections.Generic;
using System.Reflection;

namespace ContactTask.PresentationService
{
    public class ContactPresentationService : IContactPresentationService
    {
        private readonly IContactDomainService contactDomain;

        public ContactPresentationService(IContactDomainService contactDomain)
        {
            this.contactDomain = contactDomain;
        }

        public void AddContact(CreateContactViewModel viewModel)
        {
            Contact contact = Mapper.Map<CreateContactViewModel, Contact>(viewModel);
            contactDomain.AddContact(contact);
        }

        public ICollection<ContactViewModel> GetAllContacts()
        {
            List<ContactViewModel> contacts = new List<ContactViewModel>();
            
            foreach (var item in contactDomain.GetAllContacts())
            {
                contacts.Add(Mapper.Map<ContactViewModel>(item));
            }

            return contacts;
        }

        public void DeleteContact(EditContactViewModel viewModel)
        {
            Contact contact = Mapper.Map<EditContactViewModel, Contact>(viewModel);
            contactDomain.DeleteContact(contact);
        }

        public ICollection<string> GetColumnsNameWithoutId()
        {
            List<string> vs = new List<string>();

            PropertyInfo[] fields = typeof(ContactViewModel).GetProperties();

            foreach (var item in fields)
            {
                if (item.Name == "Id")
                {
                    continue;
                }
                vs.Add(item.Name);
            }

            return vs;
        }

        public EditContactViewModel GetContactById(int id)
        {
            return Mapper.Map<EditContactViewModel>(contactDomain.GetContactById(id));
        }

        public void EditContact(EditContactViewModel viewModel)
        {
            Contact contact = Mapper.Map<EditContactViewModel, Contact>(viewModel);
            contactDomain.EditContact(contact);
        }
    }
}