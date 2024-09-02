using PatientMedicAPI.Dto.Patient;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.BL.Helpers
{
    public class PatientDtoMapper
    {
        public static PatientEditDto MapPatientToPatientEditDto(Patient patient)
        {
            return new PatientEditDto()
            {
                PatientAddress = patient.PatientAddress,
                PatientBirthday = patient.PatientBirthday,
                PatientFirstName = patient.PatientFirstName,
                PatientLastName = patient.PatientLastName,
                PatientGender = patient.PatientGender,
                PatientId = patient.PatientId,
                PatientPatronymic = patient.PatientPatronymic,
                SectionId = patient.SectionId
            };
        }
        public static PatientListDto MapPatientToPatientListDto(Patient patient)
        {
            return new PatientListDto()
            {
                PatientAddress = patient.PatientAddress,
                PatientBirthday = patient.PatientBirthday,
                PatientFirstName = patient.PatientFirstName,
                PatientLastName = patient.PatientLastName,
                PatientGender = patient.PatientGender,
                PatientId = patient.PatientId,
                PatientPatronymic = patient.PatientPatronymic,
                SectionNumber = patient.Section.SectionNumber
            };
        }
    }
}
