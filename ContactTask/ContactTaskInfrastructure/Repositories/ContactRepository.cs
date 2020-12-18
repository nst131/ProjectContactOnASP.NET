using ContactTaskDomain.Entities;
using ContactTaskDomain.Repositories;
using ContactTaskDomain.UnitOfWork;

namespace ContactTaskInfrastructure.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
