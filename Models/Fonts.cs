﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWebApiService.Models;

public partial class Fonts
{
    public Fonts(Fonts font)
    {
        Id = font.Id == Guid.Empty ? Guid.NewGuid() : font.Id;
        Title = font.Title;
        Description = font.Description;
        Value = font.Value;
    }
    public Fonts()
    {
        FontConfiguration = new HashSet<FontConfiguration>();
        WindowLocationConfiguration = new HashSet<WindowLocationConfiguration>();
    }
    [Key]
    public Guid Id { get; set; }

    [StringLength(50)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Value { get; set; } = null!;

    [InverseProperty("Font")]
    public virtual ICollection<FontConfiguration> FontConfiguration { get; set; } = new List<FontConfiguration>();

    [InverseProperty("WindowLocation")]
    public virtual ICollection<WindowLocationConfiguration> WindowLocationConfiguration { get; set; } = new List<WindowLocationConfiguration>();
}