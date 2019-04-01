using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sistema.Competicao.Data;
using Sistema.Competicao.Domain;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Sistema.Competicao.Domain.Account;

namespace Sistema.Competicao.DI
{
    public class InjectDependencies
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataBaseContext>(opt => opt.UseMySql(connectionString));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
                {
                    opt.LoginPath = "/Admin/Account/Login";
                    opt.LogoutPath = "/Admin/Account/Logout";
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                });

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IAuthentication), typeof(Authentication));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            #region Account

            services.AddTransient(typeof(UsuarioBU));
            services.AddTransient(typeof(PerfilBU));

            #endregion Account
        }
    }
}
