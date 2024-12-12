﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ConfigurationWebApiService.Models;

namespace ConfigurationWebApiService.Data;

public partial class ConfugurationManagerDbContext : DbContext
{
    public ConfugurationManagerDbContext()
    {
    }

    public ConfugurationManagerDbContext(DbContextOptions<ConfugurationManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ColourSchemaConfiguration> ColourSchemaConfiguration { get; set; }

    public virtual DbSet<ColourSchemas> ColourSchemas { get; set; }

    public virtual DbSet<Configurations> Configurations { get; set; }

    public virtual DbSet<EventSubscription> EventSubscription { get; set; }

    public virtual DbSet<FontConfiguration> FontConfiguration { get; set; }

    public virtual DbSet<Fonts> Fonts { get; set; }

    public virtual DbSet<HotKeyConfigurations> HotKeyConfigurations { get; set; }

    public virtual DbSet<Hotkeys> Hotkeys { get; set; }

    public virtual DbSet<SubscriptionEventSubscription> SubscriptionEventSubscription { get; set; }

    public virtual DbSet<Subscriptions> Subscriptions { get; set; }

    public virtual DbSet<UserConfiguration> UserConfiguration { get; set; }

    public virtual DbSet<UserSubscriptions> UserSubscriptions { get; set; }

    public virtual DbSet<UserTrackingObject> UserTrackingObject { get; set; }

    public virtual DbSet<UserTrackingObjectEventSubscription> UserTrackingObjectEventSubscription { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<WindowLocationConfiguration> WindowLocationConfiguration { get; set; }

    public virtual DbSet<WindowLocations> WindowLocations { get; set; }

    public virtual DbSet<Models.Windows> Windows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ConfugurationManagerDb;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ColourSchemaConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ColourSc__3214EC07B1D663E8");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.ColourSchema).WithMany(p => p.ColourSchemaConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ColourSchemaConfiguration_To_ColourSchemas");

            entity.HasOne(d => d.Configuration).WithMany(p => p.ColourSchemaConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ColourSchemaConfiguration_To_Configurations");
        });

        modelBuilder.Entity<ColourSchemas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ColourSc__3214EC07AFA30417");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Configurations>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC07950CB197");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<EventSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07B74A4E6E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<FontConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FontConf__3214EC07755D7560");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Configuration).WithMany(p => p.FontConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FontConfiguration_To_Configurations");

            entity.HasOne(d => d.Font).WithMany(p => p.FontConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FontConfiguration_To_Fonts");
        });

        modelBuilder.Entity<Fonts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fonts__3214EC07AC396D98");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<HotKeyConfigurations>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HotKeyCo__3214EC07FEDF4431");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Configuration).WithMany(p => p.HotKeyConfigurations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HotKeyConfigurations_To_Configurations");

            entity.HasOne(d => d.HotKey).WithMany(p => p.HotKeyConfigurations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HotKeyConfigurations_To_Hotkeys");
        });

        modelBuilder.Entity<Hotkeys>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hotkeys__3214EC07350FA74C");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<SubscriptionEventSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrip__3214EC07225F573F");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.EventSubscription).WithMany(p => p.SubscriptionEventSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionEvent_To_EventSubscription");

            entity.HasOne(d => d.Subscription).WithMany(p => p.SubscriptionEventSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionEvent_To_Subscription");
        });

        modelBuilder.Entity<Subscriptions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrip__3214EC07D4F964A7");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<UserConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserConf__3214EC073DC12C21");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Configuration).WithMany(p => p.UserConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserConfiguration_To_Configurations");

            entity.HasOne(d => d.User).WithMany(p => p.UserConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserConfiguration_To_Users");
        });

        modelBuilder.Entity<UserSubscriptions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserSubs__3214EC07D00F25C1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Subscription).WithMany(p => p.UserSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionUsers_To_Subscriptions");

            entity.HasOne(d => d.User).WithMany(p => p.UserSubscriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionUsers_To_Users");
        });

        modelBuilder.Entity<UserTrackingObject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserTrac__3214EC0747361B99");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserTrackingObjectEventSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserTrac__3214EC072D321195");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.EventSubscription).WithMany(p => p.UserTrackingObjectEventSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTrackingObjectEventSubscriptionn_To_EventSubscription");

            entity.HasOne(d => d.UserTrackingObject).WithMany(p => p.UserTrackingObjectEventSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserTrackingObjectEventSubscriptionn_To_UserTrackingObject");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07E3A6732E");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<WindowLocationConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WindowLo__3214EC07F045E304");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Configuration).WithMany(p => p.WindowLocationConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WindowLocationConfiguration_To_Configurations");

            entity.HasOne(d => d.WindowLocation).WithMany(p => p.WindowLocationConfiguration).HasConstraintName("FK_WindowLocationConfiguration_To_WindowLocations");
        });

        modelBuilder.Entity<WindowLocations>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WindowLo__3214EC07C2A764A1");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Window).WithMany(p => p.WindowLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WindowLocations_To_Windows");
        });

        modelBuilder.Entity<Models.Windows>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Windows__3214EC076B330601");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}