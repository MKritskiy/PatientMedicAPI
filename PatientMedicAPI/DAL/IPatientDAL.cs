using PatientMedicAPI.Dto.Patient;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.DAL
{
    public interface IPatientDAL
    {
        IEnumerable<Patient> GetList(string sortField, bool ascending, int page, int pageSize);
        Task<Patient> Get(int id);
        Task<int> Add(Patient patient);
        Task<int> Update(Patient patient);
        Task Delete(int id);

    }
}
