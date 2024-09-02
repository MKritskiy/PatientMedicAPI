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
            try { 
            return await _patientDal.Add(patient);
            }
            catch
            {
                throw new Exception("Error while adding the patient");
            }

        }

        public async Task Delete(int id)
        {
            try
            {
                await _patientDal.Delete(id);
            }
            catch
            {
                throw new Exception("Error while deleting the patient");
            }
        }

        public async Task<PatientEditDto> Get(int id)
        {
            var patient = await _patientDal.Get(id);
            if (patient.PatientId < 1)
                throw new Exception($"Patient with id = {id} not found");
            return PatientDtoMapper.MapPatientToPatientEditDto(patient);
        }

        public IEnumerable<PatientListDto> GetList(string sortField, bool ascending, int page, int pageSize)
        {
            try
            {
                var patients = _patientDal.GetList(sortField, ascending, page, pageSize);
                List<PatientListDto> patientsList = new List<PatientListDto>();
                foreach (var patient in patients)
                {
                    patientsList.Add(PatientDtoMapper.MapPatientToPatientListDto(patient));
                }
                return patientsList;
            }
            catch
            {
                throw new Exception("Error while getting a patients");
            }
        }

        public Task<int> Update(Patient patient)
        {
            try
            {
                if (patient.PatientId < 1) throw new Exception("patient id is missing");
                return _patientDal.Update(patient);
            }
            catch
            {
                throw new Exception("Error while updating the patient");
            }
        }
    }
}
