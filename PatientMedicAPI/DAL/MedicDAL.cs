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
                await context.SaveChangesAsync();  // Удаляем пациента и сохраняем изменения
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

            IQueryable<Medic> query = context.Medics.Include(p => p.Section);

            switch (sortField?.ToLower())
            {
                case "patientlastname":
                    query = ascending ? query.OrderBy(p => p.PatientLastName) : query.OrderByDescending(p => p.PatientLastName);
                    break;
                case "patientfirstname":
                    query = ascending ? query.OrderBy(p => p.PatientFirstName) : query.OrderByDescending(p => p.PatientFirstName);
                    break;
                case "patientpatronymic":
                    query = ascending ? query.OrderBy(p => p.PatientPatronymic) : query.OrderByDescending(p => p.PatientPatronymic);
                    break;
                case "patientbirthday":
                    query = ascending ? query.OrderBy(p => p.PatientBirthday) : query.OrderByDescending(p => p.PatientBirthday);
                    break;
                case "patientgender":
                    query = ascending ? query.OrderBy(p => p.PatientGender) : query.OrderByDescending(p => p.PatientGender);
                    break;
                case "sectionnumber":
                    query = ascending ? query.OrderBy(p => p.Section.SectionNumber) : query.OrderByDescending(p => p.Section.SectionNumber);
                    break;
                default:
                    query = ascending ? query.OrderBy(p => p.PatientId) : query.OrderByDescending(p => p.PatientId);
                    break;
            }
            
            return query.ToPagedList(page, pageSize);
        }

        public async Task<int> Update(Patient patient)
        {
            var context = new MedicineContext();
            context.Patients.Update(patient);
            return await context.SaveChangesAsync();
        }
    }
}
