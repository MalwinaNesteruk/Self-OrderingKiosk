using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Ordering_Kiosk.db.Model
{
    [Table("Category_type")]
    public class Category
    {
        [Key]
        [Column("type_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

    }
}
