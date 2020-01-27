using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheLastPlate2.Models
{

    [Table("Listing")]
    public class Listing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Listing_ID { get; set; }
        //[Required]
        [Display(Name ="Product ID")]
        public int Product_ID { get; set; }
        public virtual Product Product { get; set; }
        
        [Required]
        [Display(Name = "Start Date")]
        public DateTime Start_Date { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime End_Date { get; set; }
        [Required]
        [Display(Name = "Auto Recreate")]
        public byte Auto_Recreate { get; set; }
        [Required]
        [Display(Name = "Product Quantity")]
        public int Product_Quantity { get; set; }

    }
}