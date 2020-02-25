using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CapCSharpEFLibrary.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]// tells the system not to create a cyclical problem between order and orderlines
        public virtual Order Order { get; set; }// you are not going to go get the order when you get the orderline

        public virtual Product Product { get; set; }

        public OrderLine() {
        }

    }
}
