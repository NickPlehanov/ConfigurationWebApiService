﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWebApiService.Models;

public partial class UserTrackingObject
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    [InverseProperty("UserTrackingObject")]
    public virtual ICollection<UserTrackingObjectEventSubscription> UserTrackingObjectEventSubscription { get; set; } = new List<UserTrackingObjectEventSubscription>();
}