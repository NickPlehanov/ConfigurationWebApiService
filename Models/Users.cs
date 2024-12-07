﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace ConfigurationWebApiService.Models
{
    public partial class Users
    {
        public Users()
        {
            UserConfiguration = new HashSet<UserConfiguration>();
            UserSubscriptions = new HashSet<UserSubscriptions>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(80)]
        public string LastName { get; set; } = default!;
        [Required]
        [StringLength(80)]
        public string FirstName { get; set; } = default!;
        [StringLength(80)]
        public string? MiddleName { get; set; }
        [Required]
        [StringLength(10)]
        public string Login { get; set; } = default!;
        [Required]
        public string PasswordHash { get; set; } = default!;
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserConfiguration> UserConfiguration { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserSubscriptions> UserSubscriptions { get; set; }
    }
}