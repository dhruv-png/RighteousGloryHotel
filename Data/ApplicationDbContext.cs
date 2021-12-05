using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RighteousGloryHotel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RighteousGloryHotel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
