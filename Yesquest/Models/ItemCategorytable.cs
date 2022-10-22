using System.ComponentModel.DataAnnotations;

namespace Yesquest.Models
{
    public class ItemCategorytable
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
