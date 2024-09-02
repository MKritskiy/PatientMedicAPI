using PatientMedicAPI.Models;

namespace PatientMedicAPI.DAL
{
    public interface IMedicDAL
    {
        IEnumerable<Medic> GetList(string sortField, bool ascending, int page, int pageSize);
        Task<Medic> Get(int id);
        Task<int> Add(Medic medic);
        Task<int> Update(Medic medic);
        Task Delete(int id);
    }
}
