using System.ComponentModel.DataAnnotations;

namespace VillageManagementUI.Model
{
    public class DeathRecordModel
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime DateOfDeath { get; set; }
        public string CauseOfDeath { get; set; }
        public string PlaceOfDeath { get; set; }
        public string RegisteredBy { get; set; }
    }
}
