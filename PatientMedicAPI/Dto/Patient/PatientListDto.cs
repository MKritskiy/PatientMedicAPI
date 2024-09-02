namespace PatientMedicAPI.Dto.Patient
{
    public class PatientListDto
    {
        public int PatientId { get; set; }
        public string PatientLastName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientPatronymic { get; set; }
        public string PatientAddress { get; set; }
        public DateTime PatientBirthday { get; set; }
        public string PatientGender { get; set; }
        public int SectionNumber { get; set; }
        
    }
}
