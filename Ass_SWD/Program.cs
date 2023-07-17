using Ass_SWD.Business.Interface;
using Ass_SWD.Business.Repository;
using Ass_SWD.Bussiness.Interface;
using Ass_SWD.Bussiness.Repository;
using Ass_SWD.Models;
using Ass_SWD.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IPatientRepository, PatientRepository>().AddDbContext<MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("MyCnn"));

builder.Services.AddTransient<IRecordRepository, RecordRepository>().AddDbContext<MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("MyCnn"));


builder.Services.AddTransient<IFeeRepository, FeeRepository>().AddDbContext<MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("MyCnn"));


builder.Services.AddTransient<IPaymentService, PaymentService>().AddDbContext<MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("MyCnn"));

builder.Services.AddTransient<IServiceRepository, ServiceRepository>().AddDbContext<MyStoreContext>(opt =>
    builder.Configuration.GetConnectionString("MyCnn"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyStoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));
builder.Services.AddScoped<MyStoreContext>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();


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

app.MapControllers();

app.Run();
