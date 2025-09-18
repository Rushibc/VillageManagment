using System.ComponentModel.DataAnnotations;

namespace VillageManagementUI.Model
{
    public class BirthRecordModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }

        [Required]
        public string FatherName { get; set; }

        [Required]
        public string MotherName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string RegisteredBy { get; set; }

        public DateTime RegistrationDate { get; set; }
    }

}
