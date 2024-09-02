namespace PatientMedicAPI.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public int SectionNumber { get; set; }

        public List<Patient> patients { get; set; } = null!;
        public List<Medic> medics { get; set; } = null!;
    }
}
