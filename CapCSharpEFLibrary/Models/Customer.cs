using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapCSharpEFLibrary.Models
{
    public class Customer  //has to be made public
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]   // defining string length as 30 for Name
        [Required]  //  only makes sense where an entity is allowed to be nullable  we do not want name to be nullable
        public string Name { get; set; }
        public double Sales { get; set; }  // doubles are not allowed to be nullable, numeric data generally does not need additional attributes
        public bool Active { get; set; }
        
        public Customer() {}  // need a default contstuctor
    }
}
