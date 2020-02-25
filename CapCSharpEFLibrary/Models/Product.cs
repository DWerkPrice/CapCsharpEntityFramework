using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapCSharpEFLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
// because no longer needed because of sluid api in AppDbContext.cs
        //       [StringLength(10)]   // defining string length as 30 for Name
 //       [Required]// cannot be null
        public string Code { get; set; }
 //       [StringLength(30)]
 //       [Required]
        public string Name { get; set; }  // doubles are not allowed to be nullable, numeric data generally does not need additional attributes
        public double Price { get; set; }


        
        public override string ToString() => $"{Id}/{Code}/{Name}/{Price}"; //overrides

        public virtual List<OrderLine> OrderLines { get; set; }
        
        public Product() { }  // need a default contstuctor
    }
}
