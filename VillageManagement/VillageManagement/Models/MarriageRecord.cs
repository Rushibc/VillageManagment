using System.ComponentModel.DataAnnotations;

namespace VillageManagement.Models
{
    public class MarriageRecord
    {
        public int Id { get; set; }

        [Required]
        public string GroomName { get; set; }

        [Required]
        public string BrideName { get; set; }

        [Required]
        public DateTime MarriageDate { get; set; }

        public string PlaceOfMarriage { get; set; }

        public string Witnesses { get; set; }

        public string RegisteredBy { get; set; }

        public string Remarks { get; set; }

        public string CertificateNumber { get; set; }
    }
}
