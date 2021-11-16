using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using API.Repositories;

namespace API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    var frontendURL = _configuration.GetValue<string>("frontent_url");
                    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers().AddJsonOptions(options => 
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
