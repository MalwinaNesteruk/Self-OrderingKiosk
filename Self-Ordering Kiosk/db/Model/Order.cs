using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Ordering_Kiosk.db.Model
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int IdOrder { get; set; }

        [Column("is_takeaway")]
        public bool IsTakeaway { get; set; }

        [Column("date_of_order")]
        public DateTime DateOfOrder { get; set; }

        [Column("order_value")]
        public decimal OrderValue { get; set; }

        public ICollection<ProductsOrders> ProductsOrders { get; set; }
    }
}
