using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tracker
{
    public class Approval
    {
        public int Id { get; set; }
        [Required]
        //Foreign Key
        public int PetOwnerId { get; set; }
        //Navigation property
        public PetOwner PetOwner { get; set; }
        //Foreign Key
        public int PetWalkerId { get; set; }
        //Navigation property
        public PetWalker PetWalker { get; set; }

    }
}