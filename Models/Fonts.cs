﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace ConfigurationWebApiService.Models
{
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
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        [Required]
        public string Value { get; set; } = default!;

        [InverseProperty("Font")]
        public virtual ICollection<FontConfiguration> FontConfiguration { get; set; }
        [InverseProperty("WindowLocation")]
        public virtual ICollection<WindowLocationConfiguration> WindowLocationConfiguration { get; set; }
    }
}