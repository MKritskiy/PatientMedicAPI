namespace PatientMedicAPI.Models
{
    public class Specialization
    {
        public int SpecializationId { get; set; }
        public string? SpecializationName { get; set; }

        public List<Medic> medics { get; set; } = null!;
    }
}
