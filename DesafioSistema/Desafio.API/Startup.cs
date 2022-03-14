using AutoMapper;
using Desafio.API.Configuration;
using Desafio.API.Infra;
using Desafio.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Desafio.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        //This method gets called by runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //conexao com a base de dados
            string con = $"Server=localhost;Port=5432;Database=desafio_sistema;User Id=postgres;Password=123456789";
            services.AddDbContext<DesafioContext>(options => options.UseLazyLoadingProxies().UseNpgsql(con));

            //configuracao de injecao de dependencias
            services.AddScoped<IUsuarioRep, UsuarioRepositorio>();

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperConfig());
            });

            IMapper mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Desafio",
                    Version = "v1"
                });
            });
        }

        //This method gets called by the runtime. Use this method to configure the HTPP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
