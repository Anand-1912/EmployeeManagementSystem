using EmployeeAPIService.Entities;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPIService.Model.Employee
{
    public class UpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        [EnumDataType(typeof(Gender))]
        public string Gender { get; set; } = null!;
    }
}
