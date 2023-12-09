using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Movie
    {
        [Key]
        public int id_Movie { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }
        public bool IsTvShow { get; set; }
        public string Genre { get; set; }
        public bool IsMovie { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Poster { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateOfUpload { get; set; }


        public virtual ICollection<Rental> Rentals { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}