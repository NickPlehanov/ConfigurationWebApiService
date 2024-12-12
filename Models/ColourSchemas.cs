﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationWebApiService.Models;

public partial class ColourSchemas
{
    public ColourSchemas(ColourSchemas cs)
    {
        Id = cs.Id == Guid.Empty ? Guid.NewGuid() : cs.Id;
        Title = cs.Title;
        Description = cs.Description;
        Value = cs.Value;

    }
    public ColourSchemas()
    {
        ColourSchemaConfiguration = new HashSet<ColourSchemaConfiguration>();
    }
    [Key]
    public Guid Id { get; set; }

    [StringLength(50)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Value { get; set; } = null!;

    [InverseProperty("ColourSchema")]
    public virtual ICollection<ColourSchemaConfiguration> ColourSchemaConfiguration { get; set; } = new List<ColourSchemaConfiguration>();
}