using PatientMedicAPI.BL.Helpers;
using PatientMedicAPI.DAL;
using PatientMedicAPI.Dto.Patient;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.BL
{
    public class PatientBL : IPatientBL
    {
        private readonly IPatientDAL _patientDal;

        public PatientBL(IPatientDAL patientDal)
        {
            _patientDal = patientDal;
        }

        public async Task<int> Add(Patient patient)
        {
            return await _patientDal.Add(patient);
        }

        public async Task Delete(int id)
        {
            await _patientDal.Delete(id);
        }

        public async Task<PatientEditDto> Get(int id)
        {
            var patient = await _patientDal.Get(id);
            if (patient.SectionId < 1)
                throw new Exception("Get patient exception");
            return PatientDtoMapper.MapPatientToPatientEditDto(patient);
        }

        public IEnumerable<PatientListDto> GetList(string sortField, bool ascending, int page, int pageSize)
        {
            var patients = _patientDal.GetList(sortField, ascending, page, pageSize);
            List<PatientListDto> patientsList = new List<PatientListDto>();
            foreach (var patient in patients)
            {
                patientsList.Add(PatientDtoMapper.MapPatientToPatientListDto(patient));
            }
            return patientsList;
        }

        public Task<int> Update(Patient patient)
        {
            return _patientDal.Update(patient);
        }
    }
}
