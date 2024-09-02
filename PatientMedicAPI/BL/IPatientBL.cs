using PatientMedicAPI.Dto.Patient;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.BL
{
    public interface IPatientBL
    {
        IEnumerable<PatientListDto> GetList(string sortField, bool ascending, int page, int pageSize);
        Task<PatientEditDto> Get(int id);
        Task<int> Add(Patient patient);
        Task<int> Update(Patient patient);
        Task Delete(int id);
    }
}
