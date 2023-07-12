using System.ComponentModel.DataAnnotations;

namespace Demo_App.Models
{
    public class PersonDTO
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public string Address { get; set; }
    }
}
