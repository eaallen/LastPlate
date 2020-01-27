using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheLastPlate2.Models
{
    [Table("Business")]
    public class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Business ID")]
        public int Business_ID { get; set; }

        [Required]
        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "100 letters or less")]
        public string Email { get; set; }

       /// [Required]
        [Display(Name = "Venmo")]
        [MaxLength(100, ErrorMessage = "100 letters or less")]
        public string Venmo { get; set; }

      //  [Required]
        [Display(Name = "Name")]
        [MaxLength(30, ErrorMessage = "30 letters or less")]
        public string Name { get; set; }

      //  [Required]
        [Display(Name = "Street Address")]
        [MaxLength(30, ErrorMessage = "30 letters or less")]
        public string Street { get; set; }

      //  [Required]
        [Display(Name = "City")]
        [MaxLength(30, ErrorMessage = "30 letters or less")]
        public string City { get; set; }

      //  [Required]
        [Display(Name = "State")]
        public string State { get; set; }

      //  [Required]
        [Display(Name = "Zip Code")]
        [MaxLength(5, ErrorMessage = "5 letters or less")]
        public string Zip_Code { get; set; }

      //  [Required]
        [Display(Name = "Sales Tax Percentage")]
        public double Sales_tax_percent { get; set; }

    }
}