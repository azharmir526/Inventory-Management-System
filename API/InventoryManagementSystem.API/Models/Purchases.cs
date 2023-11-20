using InventoryManagementSystem.API.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.API.Models
{
    [Table("Purchases")]
    public class Purchases : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }
        [Column("ProductsId")]
        [Required]
        public long ProductsId { get; set; }
        public virtual Products? Products { get; set; }
        [Column("Quantity")]
        public decimal Quantity { get; set; }
        [Column("OrderDate")]
        public DateTime? OrderDate { get; set; }
        [Column("ReceiptDate")]
        public DateTime? ReceiptDate { get; set; }
    }
}
