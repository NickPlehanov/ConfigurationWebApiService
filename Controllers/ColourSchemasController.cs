using ConfigurationWebApiService.Data;
using ConfigurationWebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationWebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourSchemasController : ControllerBase
    {
        [HttpGet("GetListColourSchemas")]
        public IEnumerable<ColourSchemas> GetListConfigurations()
        {
            using ConfugurationManagerDbContext context = new();
            return context.ColourSchemas.ToList();
        }
        [HttpGet("GetColourSchemasById")]
        public IEnumerable<ColourSchemas> GetConfigurationsByUser(Guid colourSchemasId)
        {
            using ConfugurationManagerDbContext context = new();
            return context.ColourSchemas.Where(x => x.Id == colourSchemasId);
        }
        [HttpPost("AddColourSchemas")]
        public bool AddColourSchemas(string title, string? description, string value)
        {
            using ConfugurationManagerDbContext context = new();
            var model = new ColourSchemas(title, description ?? string.Empty, value);
            context.ColourSchemas.Add(model);
            int res = context.SaveChanges();
            return res > 0;
        }
        [HttpPost("EditColourSchemas")]
        public bool EditColourSchemas(ColourSchemas colourSchema)
        {
            using ConfugurationManagerDbContext context = new();
            ColourSchemas? existingColourSchema = context.ColourSchemas.First(x => x.Id == colourSchema.Id);
            if (existingColourSchema != null)
            {
                existingColourSchema.Id = Guid.NewGuid();
                context.ColourSchemas.Add(existingColourSchema);
                int res = context.SaveChanges();
                return res > 0;
            }
            else
                return AddColourSchemas(colourSchema.Title, colourSchema.Description, colourSchema.Value);

        }
        [HttpPost("DeleteColourSchemas")]
        public bool DeleteColourSchemas(Guid id)
        {
            using ConfugurationManagerDbContext context = new();
            context.ColourSchemas.Remove(context.ColourSchemas.First(x => x.Id == id));
            int res = context.SaveChanges();
            return res > 0;
        }
    }
}
