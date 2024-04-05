using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClientApp.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "ID Number is required.")]
        [DisplayName("ID Number")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Invalid ID Number format.")]
        public string IDNumber { get; set; }

        [DisplayName("Physical Address")]
        public string PhysicalAddress { get; set; }
    }
}
