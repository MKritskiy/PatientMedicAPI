using Microsoft.EntityFrameworkCore;
using PagedList;
using PatientMedicAPI.Database;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.DAL
{
    public class MedicDAL : IMedicDAL
    {
        public async Task<int> Add(Medic medic)
        {
            using var context = new MedicineContext();
            await context.Medics.AddAsync(medic);
            await context.SaveChangesAsync();
            return medic.MedicId;
        }

        public async Task Delete(int id)
        {
            using var context = new MedicineContext();
            var medic = await context.Medics.FindAsync(id);
            if (medic != null)
            {
                context.Medics.Remove(medic);
                await context.SaveChangesAsync(); 
            }
        }

        public async Task<Medic> Get(int id)
        {
            using var context = new MedicineContext();
            return await context.Medics
                .Include(p => p.Section)
                .Include(p => p.Specialization)
                .Include(p => p.Cabinet)
                .FirstOrDefaultAsync(p => p.MedicId == id) ?? new Medic();
        }

        public IEnumerable<Medic> GetList(string sortField, bool ascending, int page, int pageSize)
        {
            using var context = new MedicineContext();

            IQueryable<Medic> query = context.Medics.Include(m => m.Section).Include(m=>m.Cabinet).Include(m=>m.Specialization);

            switch (sortField?.ToLower())
            {
                case "medicfullname":
                    query = ascending ? query.OrderBy(p => p.MedicFullname) : query.OrderByDescending(p => p.MedicFullname);
                    break;
                case "cabinetnumber":
                    query = ascending ? query.OrderBy(p => p.Cabinet.CabinetNumber) : query.OrderByDescending(p => p.Cabinet.CabinetNumber);
                    break;
                case "specializationname":
                    query = ascending ? query.OrderBy(p => p.Specialization.SpecializationName) : query.OrderByDescending(p => p.Specialization.SpecializationName);
                    break;
                case "sectionnumber":
                    query = ascending ? query.OrderBy(p => p.Section.SectionNumber) : query.OrderByDescending(p => p.Section.SectionNumber);
                    break;
                default:
                    query = ascending ? query.OrderBy(p => p.MedicId) : query.OrderByDescending(p => p.MedicId);
                    break;
            }
            
            return query.ToPagedList(page, pageSize);
        }

        public async Task<int> Update(Medic medic)
        {
            var context = new MedicineContext();
            context.Medics.Update(medic);
            return await context.SaveChangesAsync();
        }
    }
}
