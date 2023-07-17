
using Microsoft.EntityFrameworkCore;
using Ass_SWD.Bussiness.Interface;
using Ass_SWD.Bussiness.Repository;
using Ass_SWD.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IPatientRepository, PatientRepository>().AddDbContext<Ass_SWD.Models.MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("MyCnn"));

builder.Services.AddTransient<IRecordRepository, RecordRepository>().AddDbContext<Ass_SWD.Models.MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("MyCnn"));


builder.Services.AddTransient<IFeeRepository, FeeRepository>().AddDbContext<Ass_SWD.Models.MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("MyCnn"));

builder.Services.AddDbContext<Ass_SWD.Models.MyStoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));
builder.Services.AddScoped<Ass_SWD.Models.MyStoreContext>();

builder.Services.AddSignalR();

// session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

app.UseSession();
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
