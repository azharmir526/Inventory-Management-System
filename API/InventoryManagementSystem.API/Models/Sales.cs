using InventoryManagementSystem.API.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.API.Models
{
    [Table("Sales")]
    public class Sales : IEntity
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
        [Column("Date")]
        public DateTime? Date { get; set; }
    }
}
