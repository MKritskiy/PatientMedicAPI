using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientMedicAPI.Models
{
    public class Patient
    {

        public int PatientId { get; set; }
        public string PatientLastName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientPatronymic { get; set; }
        public string PatientAddress { get; set; }
        public DateTime PatientBirthday { get; set; }
        public string PatientGender { get; set; }
        public int SectionId { get; set; }

        // Navigation property for the related Section
        [ForeignKey("SectionId")]
        public Section? Section { get; set; }
    }
}
