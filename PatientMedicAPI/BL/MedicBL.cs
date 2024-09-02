using PatientMedicAPI.BL.Helpers;
using PatientMedicAPI.DAL;
using PatientMedicAPI.Dto.Medic;
using PatientMedicAPI.Dto.Patient;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.BL
{
    public class MedicBL : IMedicBL
    {
        private readonly IMedicDAL _medicDal;

        public MedicBL(IMedicDAL medicDal)
        {
            _medicDal = medicDal;
        }

        public async Task<int> Add(Medic medic)
        {
            try
            {
                return await _medicDal.Add(medic);
            }
            catch 
            {
                throw new Exception("Error while adding the medic");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _medicDal.Delete(id);
            }
            catch
            {
                throw new Exception("Error while deleting the medic");
            }
        }


        public async Task<MedicEditDto> Get(int id)
        {
            var medic = await _medicDal.Get(id);
            if (medic.MedicId < 1)
                throw new Exception($"Medic with id = {id} not found");
            return MedicDtoMapper.MapMedicToMedicEditDto(medic);
        }

        public IEnumerable<MedicListDto> GetList(string sortField, bool ascending, int page, int pageSize)
        {
            try
            {
                var medics = _medicDal.GetList(sortField, ascending, page, pageSize);
                List<MedicListDto> medicLists = new List<MedicListDto>();
                foreach (var medic in medics)
                {
                    medicLists.Add(MedicDtoMapper.MapMedicToMedicListDto(medic));
                }
                return medicLists;
            }
            catch
            {
                throw new Exception("Error while getting a medics");
            }
        }

        public async Task<int> Update(Medic medic)
        {
            try
            {
                if (medic.MedicId < 1) throw new Exception("medic id is missing");
                return await _medicDal.Update(medic);
            }
            catch 
            {
                throw new Exception("Error while updating the medic");
            }
        }
    }
}
