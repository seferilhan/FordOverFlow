using FordOverFlow.DataAccessLayer;
using FordOverFlow.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext"));  //connection String
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//builder.Services.AddScoped<DbInitializer>();    //seedleme iþlemi için gerekli initializer servisi

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())   
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
SeedDatabase();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


//Tablolara ön verileri eklemek için DbInitializer kullanýlýyor.
void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        DbInitializer.Initializer(dbInitializer);
    }
}