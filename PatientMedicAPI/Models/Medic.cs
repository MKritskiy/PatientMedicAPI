using System.ComponentModel.DataAnnotations.Schema;

namespace PatientMedicAPI.Models
{
    public class Medic
    {
        public int MedicId { get; set; }
        public string MedicFullname { get; set; }
        public int CabinetId { get; set; }
        public int SpecializationId { get; set; }
        public int SectionId { get; set; }

        [ForeignKey("CabinetId")]
        public Cabinet Cabinet { get; set; }
        [ForeignKey("SpecializationId")]
        public Specialization Specialization { get; set; }
        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}
