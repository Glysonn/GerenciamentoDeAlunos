using dotnetmvc.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// armazenando a connection string (configurada no app settings) nessa variável
var connectionStringMysql = builder.Configuration.GetConnectionString("BancoMysql");
// configurando o banco MYSQL
builder.Services.AddDbContext<EscolaContext>(
    options => options.UseMySql(
        connectionStringMysql,
        ServerVersion.AutoDetect(connectionStringMysql)
    )
);



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
