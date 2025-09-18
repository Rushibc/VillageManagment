namespace VillageManagement.DTO
{
    namespace BirthRegistryAPI.DTOs
    {
        public class BirthRecordReadDto
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public DateTime BirthDate { get; set; }
            public string Gender { get; set; }
            public string PlaceOfBirth { get; set; }
            public string FatherName { get; set; }
            public string MotherName { get; set; }
            public string Address { get; set; }
            public string RegisteredBy { get; set; }
            public DateTime RegistrationDate { get; set; }
        }
    }

}
