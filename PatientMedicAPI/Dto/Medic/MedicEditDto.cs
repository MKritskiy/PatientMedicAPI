namespace PatientMedicAPI.Dto.Medic
{
    public class MedicEditDto
    {
        public int MedicId { get; set; }
        public string MedicFullname { get; set; } = null!;
        public int CabinetId { get; set; }
        public int SpecializationId { get; set; }
        public int SectionId { get; set; }
    }
}   
