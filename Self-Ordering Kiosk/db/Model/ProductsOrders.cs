using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Ordering_Kiosk.db.Model
{
    [Table("Products_Orders")]
    public class ProductsOrders
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("order_id")]
        public Order Order { get; set; }

        [ForeignKey("product_id")]
        public Product Product { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
