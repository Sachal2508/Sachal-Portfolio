namespace MyPortfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();

                if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("RENDER")))
                {
                    app.UseHttpsRedirection();
                }
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
            app.Run($"http://0.0.0.0:{port}");
        }
    }
}
