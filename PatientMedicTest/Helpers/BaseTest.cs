using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientMedicAPI.BL;
using PatientMedicAPI.DAL;
using PatientMedicAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMedicTest.Helpers
{
    public class BaseTest
    {
        protected IMedicDAL medicDal = new MedicDAL();
        protected IPatientDAL patientDal = new PatientDAL();

        protected IMedicBL medicBl;
        protected IPatientBL patientBl;

        public BaseTest()
        {
            MedicineContext.ConnectionString = "Server=localhost,1433;Database=medicinedb;User Id=sa;Password=MedicinePassword1234;TrustServerCertificate=true;";

            medicBl = new MedicBL(medicDal);
            patientBl = new PatientBL(patientDal);
        }
    }
}
