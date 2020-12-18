using ContactTaskDomain.Entities;
using System;

namespace ContactTask.ViewModels
{
    public class CreateContactViewModel
    {
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public TypeDear Dear { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
    }
}