namespace PatientMedicAPI.Dto.Medic
{
    public class MedicListDto
    {
        public int MedicId { get; set; }
        public string MedicFullname { get; set; }
        public int CabinetNumber { get; set; }
        public string SpecializationName { get; set; }
        public int SectionNumber { get; set; }
    }
}
