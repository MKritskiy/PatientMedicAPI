using PatientMedicAPI.Database;
using PatientMedicAPI.Dto.Patient;
using PatientMedicAPI.Models;
using PatientMedicTest.Helpers;

namespace PatientMedicTest
{
    public class PatientTests : BaseTest
    {

        [Test]
        public async Task GetTestAsync()
        {
            using (var scope = Helper.CreateTransactionScope())
            {
                using (var context = new MedicineContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }

                Patient patient = new Patient()
                {
                    PatientLastName = "Test",
                    PatientFirstName = "Test",
                    PatientPatronymic = "Test",
                    PatientAddress = "Test Test Test",
                    PatientBirthday = new DateTime(2000, 5, 15),
                    PatientGender = "Male",
                    SectionId = 1
                };
                int res = await patientBl.Add(patient);
                Assert.Greater(res, 0);
                PatientEditDto patientEditDto = await patientBl.Get(res);
                Assert.That(patient.PatientLastName, Is.EqualTo(patientEditDto.PatientLastName));
                Patient patient_2 = new Patient()
                {
                    PatientLastName = "ZZZZ",
                    PatientFirstName = "Test2",
                    PatientPatronymic = "Test2",
                    PatientAddress = "Test2 Test2 Test2",
                    PatientBirthday = new DateTime(2000, 5, 15),
                    PatientGender = "Male",
                    SectionId = 1
                };
                int res2 = await patientBl.Add(patient_2);
                Assert.Greater(res2, 0);
                var patientList = patientBl.GetList("PatientLastName", false, 1, 1);
                Assert.Greater(patientList.Count(), 0);
                Assert.Less(patientList.Count(), 2);
                Assert.That(patientList.First().PatientLastName, Is.EqualTo(patient_2.PatientLastName));
            }
        }
        [Test]
        public async Task DeleteTest()
        {
            using (var scope = Helper.CreateTransactionScope())
            {
                using (var context = new MedicineContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
                Patient patient = new Patient()
                {
                    PatientLastName = "Test",
                    PatientFirstName = "Test",
                    PatientPatronymic = "Test",
                    PatientAddress = "Test Test Test",
                    PatientBirthday = new DateTime(2000, 5, 15),
                    PatientGender = "Male",
                    SectionId = 1
                };
                int res = await patientBl.Add(patient);
                Assert.Greater(res, 0);
                Assert.DoesNotThrowAsync(async () => await patientBl.Delete(patient.PatientId));
            }
        }
        [Test]
        public async Task UpdateTestAsync()
        {
            using (var scope = Helper.CreateTransactionScope())
            {
                using (var context = new MedicineContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
                Patient patient = new Patient()
                {
                    PatientLastName = "Test",
                    PatientFirstName = "Test",
                    PatientPatronymic = "Test",
                    PatientAddress = "Test Test Test",
                    PatientBirthday = new DateTime(2000, 5, 15),
                    PatientGender = "Male",
                    SectionId = 1
                };
                int res = await patientBl.Add(patient);
                Assert.Greater(res, 0);
                Patient patientUpdate = new Patient()
                {
                    PatientId = patient.PatientId,
                    PatientLastName = "New_Name",
                    PatientFirstName = "Test",
                    PatientPatronymic = "Test",
                    PatientAddress = "Test Test Test",
                    PatientBirthday = new DateTime(2000, 5, 15),
                    PatientGender = "Male",
                    SectionId = 1
                };
                Assert.DoesNotThrowAsync(async () => await patientBl.Update(patientUpdate));
                PatientEditDto patientAfterUpdate = await patientBl.Get(patient.PatientId);
                Assert.That(patientAfterUpdate.PatientLastName, Is.EqualTo("New_Name"));
            }
        }
    }
}