using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheLastPlate2.Models
{
    [Table("Business_Password")]
    public class BP2
    {
        [Key]
        [Display(Name = "Business ID")]
        public int Business_ID { get; set; }


        [MaxLength(30, ErrorMessage = "30 characters or less")]
        [Required]
        public string Password { get; set; }
    }
}