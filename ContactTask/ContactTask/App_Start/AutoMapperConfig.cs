using AutoMapper;
using ContactTask.ViewModels;
using ContactTaskDomain.Entities;

namespace ContactTask.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateContactViewModel, Contact>();

            cfg.CreateMap<EditContactViewModel, Contact>();

            cfg.CreateMap<Contact, EditContactViewModel>();

            cfg.CreateMap<Contact, ContactViewModel>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(z => z.BirthDate.ToString("d")))
                .ForMember(x => x.Dear, y => y.MapFrom(z => z.Dear.ToString()));
        }
    }
}