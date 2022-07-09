using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Models
{
    public class PersonHobby
    {
        [Key]
        public int PersonHobbyId { get; set; }

        [Required]
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
