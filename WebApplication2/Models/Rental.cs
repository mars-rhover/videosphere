using System.ComponentModel.DataAnnotations;
using System;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Rental
    {
        [Key]
        public int id_Rental { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateRented { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateRetrieved { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfScheduledReturn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfActualReturn { get; set; }
        public bool CancelledRental { get; set; }



        public int paymentID { get; set; }
        public virtual Payment Payment { get; set; }


        public int id_Movie { get; set; }
        public virtual Movie Movie { get; set; }


        public int UserId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }
    }
}
