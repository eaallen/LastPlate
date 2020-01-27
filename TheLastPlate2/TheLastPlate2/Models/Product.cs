using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheLastPlate2.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }
        public double Price { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "300 letters or less")]
        public string Description { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "300 letters or less")]
        public string Instructions { get; set; }
        
        [Display(Name = "Street Address")]
        [MaxLength(30, ErrorMessage = "30 letters or less")]
        public string Street { get; set; }

        
        [Display(Name = "City")]
        [MaxLength(30, ErrorMessage = "30 letters or less")]
        public string City { get; set; }

        
        [Display(Name = "State")]
        [MaxLength(2, ErrorMessage = "2")]
        public string State { get; set; }

        
        [Display(Name = "Zip Code")]
        [MaxLength(5, ErrorMessage = "5 letters or less")]
        public string Zip { get; set; }

        [Display(Name = "Date Posted")]
        public DateTime Date_Posted { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "300 letters or less")]
        [Display(Name ="Key Words")]
        public string Key_Words { get; set; }

        [Display(Name = "Business ID")]
        public int Business_ID { get; set; }
        public virtual Business Business { get; set; }
    }
}