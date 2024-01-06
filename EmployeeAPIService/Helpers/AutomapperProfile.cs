using AutoMapper;
using EmployeeAPIService.Entities;
using EmployeeAPIService.Model.Employee;

namespace EmployeeAPIService.Helpers
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<CreateRequest, Employee>();

            CreateMap<UpdateRequest, Employee>();
        }  
    }
}
