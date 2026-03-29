using AbySalto.Junior.Infrastructure.Database;
using AbySalto.Junior.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Google.Cloud.Firestore;

namespace AbySalto.Junior
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(
                        new System.Text.Json.Serialization.JsonStringEnumConverter()
                    );
                });
            
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant", Version = "v1" });
            });

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            builder.Services.AddSingleton(provider =>
            {
                Environment.SetEnvironmentVariable(
                "GOOGLE_APPLICATION_CREDENTIALS",
                @"E:\AbysaltoTest\AbysaltoTest\AbySalto.Junior\firebase-key.json"
                );

                return FirestoreDb.Create("abysaltotest");
            });

            var path = Path.Combine(Directory.GetCurrentDirectory(), "firebase-key.json");
            Console.WriteLine(path);
            Console.Write("Connected to database: ");
            Console.WriteLine(File.Exists(path));

            builder.Services.AddScoped<IOrderService, OrderService>();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();
            app.Run();
        }
    }
}


