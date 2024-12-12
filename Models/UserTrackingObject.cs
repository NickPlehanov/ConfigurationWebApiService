﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Messaging;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWebApiService.Models;

public partial class UserTrackingObject
{
    public UserTrackingObject()
    {
        
    }
    public UserTrackingObject(UserTrackingObject uto, [CallerMemberName] string caller = "")
    {
        Id = uto.Id == Guid.Empty ? Guid.NewGuid() : uto.Id;
        Title = uto.Title;
    }
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    [InverseProperty("UserTrackingObject")]
    public virtual ICollection<UserTrackingObjectEventSubscription> UserTrackingObjectEventSubscription { get; set; } = new List<UserTrackingObjectEventSubscription>();
}