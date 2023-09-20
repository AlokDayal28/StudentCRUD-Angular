using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NSwag.Annotations;

namespace StudentApi.Model
{
    public class Student
    {
        [Key]
        [SwaggerIgnore]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public int StateId { get; set; }
        public int CityId { get; set; }
        
        public string? AboutYourself { get; set; }
        public int PhotoId { get; set; }
    }
}
