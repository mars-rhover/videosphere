using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Payment
    {
        [Key]
        public int peymentID { get; set; }

        public int lateFee { get; set; }
        public string rentalPayment { get; set; }


        public virtual ICollection<Rental> Rentals { get; set; }
    }
}