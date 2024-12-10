﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWebApiService.Models;

public partial class Users
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(80)]
    public string LastName { get; set; } = null!;

    [StringLength(80)]
    public string FirstName { get; set; } = null!;

    [StringLength(80)]
    public string? MiddleName { get; set; }

    [StringLength(10)]
    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreateDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<UserConfiguration> UserConfiguration { get; set; } = new List<UserConfiguration>();

    [InverseProperty("User")]
    public virtual ICollection<UserSubscriptions> UserSubscriptions { get; set; } = new List<UserSubscriptions>();
}