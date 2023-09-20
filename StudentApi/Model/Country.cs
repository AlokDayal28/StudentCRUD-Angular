using System.ComponentModel.DataAnnotations;

namespace StudentApi.Model
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Country_Name { get; set; }
    }
}
