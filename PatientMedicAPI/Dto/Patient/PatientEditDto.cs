namespace PatientMedicAPI.Dto.Patient
{
    public class PatientEditDto
    {
        public int PatientId { get; set; }
        public string PatientLastName { get; set; } = null!;
        public string PatientFirstName { get; set; } = null!;
        public string PatientPatronymic { get; set; } = null!;
        public string PatientAddress { get; set; } = null!;
        public DateTime PatientBirthday { get; set; }
        public string PatientGender { get; set; } = null!;
        public int SectionId { get; set; }
    }
}
