using System;
using System.ComponentModel.DataAnnotations;

namespace AuthorsService.DAL.Entities
{
    public class Author
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(1)]
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
