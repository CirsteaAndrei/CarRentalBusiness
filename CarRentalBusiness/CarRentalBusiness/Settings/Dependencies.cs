using DataLayer.Repositories;
using DataLayer;
using Core.Services;

namespace CarRentalBusiness.Settings
{
    public static class Dependencies
    {

        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDbContext>();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<CarService>();
            services.AddScoped<CategoryService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<CarsRepository>();
            services.AddScoped<CategoriesRepository>();
            services.AddScoped<UnitOfWork>();
        }

    }
}
