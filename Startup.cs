
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using apidigitaldoc.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger; 

namespace apidigitaldoc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("Conn")));

            services.AddScoped<DataContext, DataContext>();
            services.AddControllers();

            // Add Cors
            services.AddCors(o => o.AddPolicy("HealthPolicy", builder => {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            
	services.AddSwaggerGen(c =>
	{
	    c.SwaggerDoc("v1", new Info { Title = "ApiDigitalDoc", Version = "v1" });
	});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

		// Enable middleware to serve generated Swagger as a JSON endpoint.
		app.UseSwagger();

		// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
		// specifying the Swagger JSON endpoint.
		app.UseSwaggerUI(c =>
		{
		    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiDigitalDoc V1");
		});

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
