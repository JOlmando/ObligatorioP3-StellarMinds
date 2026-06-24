using WebApp.Services.Http;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();


            // Definine el cliente HTTP para consumir la API

            //builder.Services.AddHttpClient("Api", c => c.BaseAddress = new Uri("http://localhost:5243"));

            builder.Services.AddHttpClient("Api", c => c.BaseAddress = new Uri("http://stellarminds207448.somee.com/"));

            // Definine el cliente HTTP para consumir la Map de Google
            //builder.Services.AddHttpClient("GoogleMaps", c => c.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/"));


            // Registrar auxiliar http (síncrono simple)
            builder.Services.AddScoped<AuxiliarClienteHttp>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
