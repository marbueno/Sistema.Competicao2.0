using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sistema.Competicao.Data;
using Sistema.Competicao.Domain;
using System;

namespace Sistema.Competicao.DI
{
    public class InjectDependencies
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataBaseContext>(opt => opt.UseMySql(connectionString));
            services.ConfigureApplicationCookie(opt => opt.LoginPath = "/Admin/Account/Login");

            services.AddAuthentication("CookieAuthentication")
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/Admin/Account/Login";
                    opt.LogoutPath = "/Admin/Account/Logout";
                    opt.ExpireTimeSpan = TimeSpan.FromDays(150);
                });

            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton(typeof(QuadraBU));
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
