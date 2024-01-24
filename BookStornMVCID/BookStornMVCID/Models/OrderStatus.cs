using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStornMVCID.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        public int Id { get; set; }
        public int StatusId { get; set; }

        [Required,MaxLength(40)]
        public string? StatusName { get; set; }
    }
}
