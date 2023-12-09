using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime dateRegistered { get; set; }

       
        public int postalCode { get; set; }

        public string Adresse { get; set; }

        public string Password { get; set; }


        public virtual ICollection<Rental> Rentals { get; set; }


        public virtual ICollection<Reservation> Reservations { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez que l'authenticationType doit correspondre à celui défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter des revendications utilisateur personnalisées ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        //public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
      
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       public System.Data.Entity.DbSet<WebApplication2.Models.ApplicationUser> ApplicationUsers { get; set; }

        // public System.Data.Entity.DbSet<WebApplication2.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<WebApplication2.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}