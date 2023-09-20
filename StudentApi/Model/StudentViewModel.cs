using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StudentApi.Model
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public int StateId { get; set; }
        public int CityId { get; set; }
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string CityName { get; set; }
        public string? AboutYourself { get; set; }
        public int PhotoId { get; set; }
        public virtual City City { get; set; } = null!;
        public virtual State State { get; set; } = null!;
    }
}
