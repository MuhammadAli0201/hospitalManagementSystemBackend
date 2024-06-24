using HospitalManagementSystemBackend.DAL;
using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<HMSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//REPOSITORIES
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IGenderRepository,GenderRepository>();
builder.Services.AddScoped<IDoctorRepository,DoctorRepository>();
builder.Services.AddScoped<IPatientRepository,PatientRepository>();
builder.Services.AddScoped<IPatientTokenRepository,PatientTokenRepository>();
builder.Services.AddScoped<IPatientScriptRepository,PatientScriptRepository>();
builder.Services.AddScoped<IMedicineRepository,MedicineRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
            options.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
