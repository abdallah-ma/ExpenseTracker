using ExpenseTracker.DAL.Data;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.BLL.Repositories;
using Microsoft.AspNetCore.Builder;
using ExpenseTracker.PL.Helpers;
using AutoMapper;
using ExpenseTracker.PL.Extensions;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

builder.Services.AddDbContext<AppDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection") ));

var scope = builder.Services.BuildServiceProvider().CreateScope();

var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

dbContext.Database.Migrate();

var app = builder.Build();



app.UseRouting();

app.UseStaticFiles();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseEndpoints(endpoints => {

    

    endpoints.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    );

    

}

   );

app.Run();
