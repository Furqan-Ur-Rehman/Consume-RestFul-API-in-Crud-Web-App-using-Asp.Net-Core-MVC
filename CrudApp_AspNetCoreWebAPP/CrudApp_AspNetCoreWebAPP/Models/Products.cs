using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudApp_AspNetCoreWebAPP.Models
{
    

     public class Products
     {
        
        [DisplayName("Item Id")]
        public int itemId { get; set; }
        [Required]
        [DisplayName("Item Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please Enter Character between 5 and 20.")]
        public string itemName { get; set; } = null!;
        [Required]
        [DisplayName("Item Description")]
        [StringLength(20, MinimumLength = 5)]
        public string itemDescription { get; set; } = null!;
        [Required]
        [DisplayName("Item Price")]
        public int itemPrice { get; set; }
     }

    
}
