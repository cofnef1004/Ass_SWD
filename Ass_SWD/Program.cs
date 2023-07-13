using Ass_SWD.Bussiness.Interface;
using Ass_SWD.Bussiness.Repository;
using Ass_SWD.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IPatientRepository, PatientRepository>().AddDbContext<MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));

builder.Services.AddTransient<IRecordRepository, RecordRepository>().AddDbContext<MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));


builder.Services.AddTransient<IFeeRepository, FeeRepository>().AddDbContext<MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("DB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
