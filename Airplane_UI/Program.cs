using Airplane_UI.Data;
using Airplane_UI.Components;
using Microsoft.EntityFrameworkCore;
using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.Services.GateAssignments;
using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Services.LuggageMaintnance;

namespace Airplane_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRazorComponents()
                            .AddInteractiveServerComponents();

            // Add Db context config
            builder.Services.AddDbContext<AirplaneManagementSystemContext>(opt => opt.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));
            #region GateAssignments Services
            builder.Services.AddScoped<IGateService, GateService>();
            #endregion

            #region LuggageMaintnance Services
            builder.Services.AddScoped<IBaggageClaimService, BaggageClaimService>();
            builder.Services.AddScoped<ILostAndFoundService, LostAndFoundService>();
            builder.Services.AddScoped<IMaintenanceLogService, MaintenanceLogService>();
            builder.Services.AddScoped<IMaintenanceTaskService, MaintenanceTaskService>();
            builder.Services.AddScoped<ICateringFacilitiesService, CateringFacilitiesService>();
            builder.Services.AddScoped<ICateringOrderService, CateringOrderService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
