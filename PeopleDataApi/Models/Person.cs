using System.ComponentModel.DataAnnotations;

namespace PeopleDataApi.Models
{
    public class Person
    {
        [Required]
        public int NumberId { get; set; } 

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
    }
}
