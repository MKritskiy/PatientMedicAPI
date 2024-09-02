using Microsoft.EntityFrameworkCore;
using PagedList;
using PatientMedicAPI.Database;
using PatientMedicAPI.Models;

namespace PatientMedicAPI.DAL
{
    public class PatientDAL : IPatientDAL
    {
        public async Task<int> Add(Patient patient)
        {
            using var context = new MedicineContext();
            await context.Patients.AddAsync(patient);
            await context.SaveChangesAsync();
            return patient.PatientId;
        }

        public async Task Delete(int id)
        {
            using var context = new MedicineContext();
            var patient = await context.Patients.FindAsync(id);
            if (patient != null)
            {
                context.Patients.Remove(patient);
                await context.SaveChangesAsync(); 
            }
        }

        public async Task<Patient> Get(int id)
        {
            using var context = new MedicineContext();
            return await context.Patients
                .Include(p => p.Section)
                .FirstOrDefaultAsync(p => p.PatientId == id) ?? new Patient();
        }

        public IEnumerable<Patient> GetList(string sortField, bool ascending, int page, int pageSize)
        {
            using var context = new MedicineContext();

            IQueryable<Patient> query = context.Patients.Include(p => p.Section);

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
