using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapCSharpEFLibrary.Models
{
    public class Order { 

        public int Id { get; set; }
        [StringLength(30)]   // defining string length as 30 for Name
        [Required]
        public string Description { get; set; }
        public double Amount { get; set; }  // doubles are not allowed to be nullable, numeric data generally does not need additional attributes
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } // does not add a column allows for an instance of customer in our order

        public override string ToString() => $"{Id}/{Description}/{Amount}/{CustomerId}"; //overrides

        public virtual List<OrderLine> OrderLines { get; set; }

        public Order() { }  // need a default contstuctor
    }
}
