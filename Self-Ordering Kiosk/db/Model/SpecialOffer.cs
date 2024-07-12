using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Ordering_Kiosk.db.Model
{
    [Table("Special_offer")]
    public class SpecialOffer
    {
        [Key]
        [Column("special_id")]
        public int SpecialId { get; set; }

        [ForeignKey("product_id")]
        public Product Product { get; set; }
    }
}
