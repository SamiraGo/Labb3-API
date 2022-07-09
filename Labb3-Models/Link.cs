using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_API.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }

        public string URL { get; set; }

        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
