using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApi.Model
{
    public class City
    {
        public int Id { get; set; }

        public string City_Name { get; set; } = null!;

        public int State_Id { get; set; }
    }
}
