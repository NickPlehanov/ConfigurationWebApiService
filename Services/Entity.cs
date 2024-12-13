using System.ComponentModel.DataAnnotations;

namespace ConfigurationWebApiService.Services;

public abstract class Entity
{
    [Key] public Guid Id { get; set; }
}