namespace PatientMedicAPI.Dto.Medic
{
    public class MedicListDto
    {
        public int MedicId { get; set; }
        public string MedicFullname { get; set; } = null!;
        public int CabinetNumber { get; set; }
        public string SpecializationName { get; set; } = null!;
        public int SectionNumber { get; set; }
    }
}
