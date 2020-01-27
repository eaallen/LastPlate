using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace TheLastPlate2.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cust_ID { get; set; }


        [Required(ErrorMessage = "Must input an email")]
        [MaxLength(100, ErrorMessage = "100 characters or less including spaces")]
        public string Cust_Email { get; set; }

        [Required(ErrorMessage = "Must create a user name")]
        [MaxLength(30, ErrorMessage = "30 characters or less including spaces")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "Input City")]
        [MaxLength(100, ErrorMessage = "30 characters or less including spaces")]
        public string City { get; set; }

        [Required(ErrorMessage = "Must input zip code")]
        [MaxLength(5, ErrorMessage = "5 characters or less including spaces")]
        public string Cust_Zip_Code { get; set; }

            
        public byte Promo_email { get; set; }
    }
}