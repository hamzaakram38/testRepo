using System.ComponentModel.DataAnnotations;

namespace Demo_App.Models
{
    public class Address
    {
        [Required]

        public string Street { get; set; }
        [Required]

        public string House { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string State { get; set; }
        [Required]

        public string Country { get; set; }

        [Required]

        public int personId { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
