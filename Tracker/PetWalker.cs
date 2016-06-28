using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tracker
{
    public class PetWalker
    {
        public int Id { get; set; }
        [Required]
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Email { get; set; }

        public int Phone { get; set; }
    }
}