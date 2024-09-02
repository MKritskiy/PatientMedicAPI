using PatientMedicAPI.Database;
using PatientMedicAPI.Dto.Medic;
using PatientMedicAPI.Models;
using PatientMedicTest.Helpers;

namespace PatientMedicTest
{
    public class MedicTests : BaseTest
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

                Medic medic = new Medic()
                {
                    CabinetId = 1,
                    MedicFullname = "Fullname",
                    SectionId = 1,
                    SpecializationId = 1
                };
                int res = await medicBl.Add(medic);
                Assert.Greater(res, 0);
                MedicEditDto medicEditDto = await medicBl.Get(res);
                Assert.That(medic.MedicFullname, Is.EqualTo(medicEditDto.MedicFullname));
                Medic medic_2 = new Medic()
                {
                    CabinetId = 2,
                    MedicFullname = "Fullname2",
                    SectionId = 2,
                    SpecializationId = 2
                };
                int res2 = await medicBl.Add(medic_2);
                Assert.Greater(res2, 0);
                var medicList = medicBl.GetList("MedicFullname", false, 1, 1);
                Assert.Greater(medicList.Count(), 0);
                Assert.Less(medicList.Count(), 2);
                Assert.That(medicList.First().MedicFullname, Is.EqualTo(medic_2.MedicFullname));
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
                Medic medic = new Medic()
                {
                    CabinetId = 1,
                    MedicFullname = "Fullname",
                    SectionId = 1,
                    SpecializationId = 1
                };
                int res = await medicBl.Add(medic);
                Assert.Greater(res, 0);
                Assert.DoesNotThrowAsync(async () => await medicBl.Delete(medic.MedicId));
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
                Medic medic = new Medic()
                {
                    CabinetId = 1,
                    MedicFullname = "Fullname",
                    SectionId = 1,
                    SpecializationId = 1
                };
                int res = await medicBl.Add(medic);
                Assert.Greater(res, 0);
                Medic medicUpdate = new Medic()
                {
                    MedicId = medic.MedicId,
                    CabinetId = 1,
                    MedicFullname = "Fullname_new",
                    SectionId = 1,
                    SpecializationId = 1
                };
                Assert.DoesNotThrowAsync(async () => await medicBl.Update(medicUpdate));
                MedicEditDto medicAfterUpdate = await medicBl.Get(medic.MedicId);
                Assert.That(medicAfterUpdate.MedicFullname, Is.EqualTo("Fullname_new"));
            }
        }
    }
}