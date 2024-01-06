using FirstWebCoreApplication2.Models.Data;
using FirstWebCoreApplication2.Models.Interfaces;
using FirstWebCoreApplication2.Services;
using Microsoft.EntityFrameworkCore;

namespace FirstWebCoreApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Veritabaný baðlantýsý ekleme
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbConnection"))
            );

            // Servis kayýtlarý
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<IBlogService, BlogService>();

            // Yeni eklenen servisler
            builder.Services.AddTransient<ICommentService, CommentService>();
            builder.Services.AddTransient<ILikeService, LikeService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
