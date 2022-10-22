using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yesquest.Models
{
    public class Itemtable
    {
        [Key]
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public ItemCategorytable Category { get; set; }


        public int QtyStock { get; set; }


    }
}
