namespace PatientMedicAPI.Models
{
    public class Cabinet
    {
        public int CabinetId { get; set; }
        public int CabinetNumber { get; set; }

        public List<Medic> medics { get; set; } = null!;
    }
}
