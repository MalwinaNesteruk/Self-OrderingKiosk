using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Self_Ordering_Kiosk.db.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("picture")]
        public string Picture { get; set; }

        [Column("description")]
        public string Description { get; set; }

/*        [Column("type")]
        public int Type { get; set; }*/

        [ForeignKey("type")]
        public Category Category { get; set; }

        public override bool Equals(object? obj)
        {
            Product product = obj as Product;
            return product.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public ICollection<ProductsOrders> ProductsOrders { get; set; }
    }
}