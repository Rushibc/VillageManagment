namespace VillageManagement.Models
{
    public class DeathRecord
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string CauseOfDeath { get; set; }
        public string PlaceOfDeath { get; set; }
        public string RegisteredBy { get; set; }
    }
}
