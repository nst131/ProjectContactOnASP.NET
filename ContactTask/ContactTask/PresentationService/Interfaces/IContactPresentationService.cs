using ContactTask.ViewModels;
using System.Collections.Generic;

namespace ContactTask.PresentationService.Interfaces
{
    public interface IContactPresentationService : IBasePresentationService
    {
        void AddContact(CreateContactViewModel viewModel);
        void DeleteContact(EditContactViewModel viewModel);
        void EditContact(EditContactViewModel viewModel);
        ICollection<ContactViewModel> GetAllContacts();
        ICollection<string> GetColumnsNameWithoutId();
        EditContactViewModel GetContactById(int id);
    }
}
