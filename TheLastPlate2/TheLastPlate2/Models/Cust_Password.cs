using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheLastPlate2.Models
{
    [Table("Cust_Password")]
    public class Cust_Password
    {
        [Key]
        [Display(Name = "Customer ID")]
        [Column(Order =0)]
        public int Cust_ID { get; set; }
        public virtual Customer Customer { get; set; }

        [MaxLength(30, ErrorMessage ="30 characters or less")]
        [Required]
        [Column(Order = 1)]
        public string Password { get; set; }
    }
}