﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWebApiService.Models;

public partial class UserConfiguration
{
    public UserConfiguration()
    {

    }
    public UserConfiguration(UserConfiguration userConfiguration)
    {
        Id = userConfiguration.Id == Guid.Empty ? Guid.NewGuid() : userConfiguration.Id;
        UserId = userConfiguration.UserId;
        ConfigurationId = userConfiguration.ConfigurationId;
    }
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ConfigurationId { get; set; }

    [ForeignKey("ConfigurationId")]
    [InverseProperty("UserConfiguration")]
    public virtual Configurations Configuration { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserConfiguration")]
    public virtual Users User { get; set; } = null!;
}