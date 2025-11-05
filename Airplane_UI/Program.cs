using Airplane_UI.Data;
using Airplane_UI.Components;
using Airplane_UI.Contracts.GateAssignments;
using Airplane_UI.Contracts.LuggageMaintnance;
using Airplane_UI.Services.GateAssignments;
using Airplane_UI.Services.LuggageMaintnance;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Airplane_UI.Contracts.AirlineCore;
using Airplane_UI.Services.AirlineCore;

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
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            builder.Services.AddRazorComponents()
                            .AddInteractiveServerComponents();


            // Add Db context config
            builder.Services.AddDbContext<AirplaneManagementSystemContext>(opt => opt.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

            #region GateAssignments Services
            builder.Services.AddScoped<IGateService, GateService>(); 
            builder.Services.AddScoped<IGateAssignmentService, GateAssignmentService>();
            builder.Services.AddScoped<ITerminalService, TerminalService>();
            builder.Services.AddScoped<IGroundCrewTeamService, GroundCrewTeamService>();
            builder.Services.AddScoped<IRunwayService, RunwayService>();
            builder.Services.AddScoped<IRunwayScheduleService, RunwayScheduleService>();
            #endregion

            // Inject Services
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
