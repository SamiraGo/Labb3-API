using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Link> Links { get; set; }

        public ICollection<PersonHobby> PersonHobbies { get; set; }


    }
}
