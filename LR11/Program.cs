namespace LR11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(typeof(LogActionFilter));
                options.Filters.Add(typeof(UniqueUsersFilter));

            });
            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "",
                defaults: new { controller = "Home", action = "Index" });


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Run();
        }
    }
}




