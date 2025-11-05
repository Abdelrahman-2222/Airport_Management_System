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
            #endregion

            #region AirlineCore Services

            builder.Services.AddScoped<IAirportService, AirportService>();
            builder.Services.AddScoped<IAirlineService, AirlineService>();
            builder.Services.AddScoped<IAircraftService, AircraftService>();
            builder.Services.AddScoped<IFlightService, FlightService>();
            builder.Services.AddScoped<IPassengerService, PassengerService>();

            #endregion


            // Inject Services
            builder.Services.AddScoped<IBaggageClaimService, BaggageClaimService>();

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
