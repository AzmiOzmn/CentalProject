﻿using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cental.DataAccessLayer.Context
{
    public class CentalContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-65IOJF7;Database=CentalDB;Integrated Security=True;trustServerCertificate=true");
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<UserSocial> UserSocials { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<FooterContact> FooterContacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
