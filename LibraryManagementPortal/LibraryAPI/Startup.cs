using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LibraryAPI.Middlewares;
using LibraryAPI.Resources;

namespace LibraryAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: StringResource.CorsAllowedOrigin,
                    builder => builder
                        .WithOrigins("http://localhost:3000")
                        .WithOrigins("http://172.16.26.33:3000/")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                );
            });

            services.AddControllers();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryAPI", Version = "v1" }));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddDbContext<LibraryContext>(opts =>
                opts
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("sqlConnection"),
                        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddTransient<UserRepository>();
            services.AddTransient<BookRepository>();
            services.AddTransient<CategoryRepository>();
            services.AddTransient<RequestRepository>();
            services.AddTransient<CurrentUserRepository>();

            services.AddScoped<BookService>();
            services.AddScoped<UserService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<RequestService>();
            services.AddScoped<HomeService>();
            services.AddScoped<CurrentUserService>();
            services.AddScoped<ResultService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(StringResource.CorsAllowedOrigin);

            app.UseRouting();

            app.UseAuthorization();

            app.UseAllowOriginMiddleware();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
