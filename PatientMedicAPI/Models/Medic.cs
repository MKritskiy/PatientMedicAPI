using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PatientMedicAPI.Models
{
    public class Medic
    {
        public int MedicId { get; set; }
        public string? MedicFullname { get; set; }
        public int CabinetId { get; set; }
        public int SpecializationId { get; set; }
        public int SectionId { get; set; }

        [ForeignKey("CabinetId")]
        [JsonIgnore]
        public Cabinet? Cabinet { get; set; }
        [ForeignKey("SpecializationId")]
        [JsonIgnore]
        public Specialization? Specialization { get; set; }
        [ForeignKey("SectionId")]
        [JsonIgnore]
        public Section? Section { get; set; }
    }
}
