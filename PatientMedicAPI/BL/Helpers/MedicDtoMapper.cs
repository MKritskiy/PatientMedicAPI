using PatientMedicAPI.Dto.Medic;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.BL.Helpers
{
    public class MedicDtoMapper
    {
        public static MedicEditDto MapMedicToMedicEditDto(Medic medic)
        {
            return new MedicEditDto()
            {
                CabinetId = medic.CabinetId,
                MedicFullname = medic.MedicFullname,
                MedicId = medic.MedicId,
                SectionId = medic.SectionId,
                SpecializationId = medic.SpecializationId
            };
        }
        public static MedicListDto MapMedicToMedicListDto(Medic medic)
        {
            return new MedicListDto()
            {
                CabinetNumber = medic.Cabinet.CabinetNumber,
                MedicFullname = medic.MedicFullname,
                MedicId = medic.MedicId,
                SectionNumber = medic.Section.SectionNumber,
                SpecializationName = medic.Specialization.SpecializationName
            };
        }
    }
}
