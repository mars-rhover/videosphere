using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication2.Models
{
    public class Reservation
    {
        [Key]
        public int id_Reservation { get; set; }
        public DateTime dateReserved { get; set; }


        public int id_Movie { get; set; }
        public virtual Movie Movie { get; set; }

        public int UserId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }

    }
}