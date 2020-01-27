using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TheLastPlate2.Models;
//transaction = TXN
namespace TheLastPlate2.Models
{
    [Table("TXN")]
    public class TXN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TXN_ID { get; set; }

        [Required]
        [Display(Name ="Customer ID")]
        public int Cust_ID { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        [Display(Name = "Listing ID")]
        public int Listing_ID { get; set; }
        public virtual Listing Listing { get; set; }
        [Required]
        [Display(Name = "Purchased Quantity")]
        public int Purchased_Quantity { get; set; }
        [Required]
        [Display(Name = "Total Price")]
        public double Total_Price { get; set; }
        [Required]
        [Display(Name = "Date of Transaction")]
        public DateTime Date_of_Transaction { get; set; }
    }
}