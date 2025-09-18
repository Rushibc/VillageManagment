using System.ComponentModel.DataAnnotations;

namespace VillageManagementUI.Model
{
    public class BirthRecordCreateDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
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
    }
}
