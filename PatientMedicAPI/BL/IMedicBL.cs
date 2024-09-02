using PatientMedicAPI.Dto.Medic;
using PatientMedicAPI.Dto.Patient;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.BL
{
    public interface IMedicBL
    {
        IEnumerable<MedicListDto> GetList(string sortField, bool ascending, int page, int pageSize);
        Task<MedicEditDto> Get(int id);
        Task<int> Add(Medic medic);
        Task<int> Update(Medic medic);
        Task Delete(int id);
    }
}
