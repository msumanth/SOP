﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SOP.Core.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SOPEntities : DbContext
    {
        public SOPEntities()
            : base("name=SOPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<PaymentSummary> PaymentSummaries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SecretQuestion> SecretQuestions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<SopUser> SopUsers { get; set; }
        public DbSet<SubscriptionPackage> SubscriptionPackages { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
    }
}