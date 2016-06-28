using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tracker
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        public DateTime DateOfBirth { get; set; }
        //Foreign Key
        public int PetOwnerId { get; set; }
        //Navigation property
        public PetOwner PetOwner { get; set; }
    }
}