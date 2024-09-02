
using PatientMedicAPI.BL;
using PatientMedicAPI.DAL;
using PatientMedicAPI.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MedicineContext>(ServiceLifetime.Scoped);
builder.Services.AddSingleton<IPatientDAL, PatientDAL>();
builder.Services.AddSingleton<IPatientBL, PatientBL>();
builder.Services.AddSingleton<IMedicDAL, MedicDAL>();
builder.Services.AddSingleton<IMedicBL, MedicBL>();




builder.Services.AddControllers();



var app = builder.Build();


app.MapControllers();

app.Run();
