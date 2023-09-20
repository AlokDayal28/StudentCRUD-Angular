using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApi.Model
{
    public class State
    {
        public int Id { get; set; }

        public string State_Name { get; set; } = null!;

        public int Country_Id { get; set; }
    }
}
