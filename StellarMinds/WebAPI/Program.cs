using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using StellarMinds.Infraestructura.AccesoDatos.EF;
using StellarMinds.Infraestructura.AccesoDatos.Repositorios;
using StellarMinds.LogicaAplicacion.CasosUso.Equipos;
using StellarMinds.LogicaAplicacion.CasosUso.Logs;
using StellarMinds.LogicaAplicacion.CasosUso.ObjetosCelestes;
using StellarMinds.LogicaAplicacion.CasosUso.Observaciones;
using StellarMinds.LogicaAplicacion.CasosUso.Prestamos;
using StellarMinds.LogicaAplicacion.CasosUso.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.Logs;
using StellarMinds.LogicaAplicacion.Dtos.ObjetoCeleste;
using StellarMinds.LogicaAplicacion.Dtos.Observacion;
using StellarMinds.LogicaAplicacion.Dtos.Prestamo;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaNegocio.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.InterfacesRepositorio;
using StellarMinds.WebAPI.Services;
using System.Reflection;
using System.Text;
//using StellarMinds.LogicaAplicacion;

namespace StellarMinds.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Inyección de dependencia Repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamo>();
            builder.Services.AddScoped<IRepositorioPrestamoDetalle, RepositorioPrestamoDetalles>();
            builder.Services.AddScoped<IRepositorioLog, RepositorioLog>();
            builder.Services.AddScoped<IRepositorioObservacion, RepositorioObservacion>();
            builder.Services.AddScoped<IRepositorioObjetoCeleste, RepositorioObjetoCeleste>();

            // Inyección de dependencia Casos de Uso Login
            builder.Services.AddScoped<ICULoginUsuario<UsuarioRol>, LoginUsuario>();

            // Inyección de dependencia Casos de Uso Usuarios
            builder.Services.AddScoped<ICUAdd<UsuarioAltaDto>, AddUsuario>();
            //builder.Services.AddScoped<ICUGetAll<GetUsuarioDto>, GetAllUsuarios>();
            builder.Services.AddScoped<ICUGetAll<GetUsuarioDto>, GetAllSocios>();
            builder.Services.AddScoped<ICUGetById<GetUsuarioDto>, GetByIdUsuario>();
            builder.Services.AddScoped<ICUUpdate<UsuarioAltaDto>, UpdateUsuario>();
            builder.Services.AddScoped<ICUDelete<UsuarioDeleteDto>, DeleteUsuario>();
            builder.Services.AddScoped<ICUGetById<IEnumerable<GetUsuarioDto>>, GetSociosByTelescopio>();

            // Inyección de dependencia Casos de Uso Equipos
            builder.Services.AddScoped<ICUAdd<EquiposDto>, AddEquipo>();
            builder.Services.AddScoped<ICUDelete<EquipoDeleteDto>, DeleteEquipo>();
            builder.Services.AddScoped<ICUGetById<EquiposDto>, GetByIdEquipo>();
            builder.Services.AddScoped<ICUGetAll<EquiposDto>, GetAllEquipos>();
            builder.Services.AddScoped<ICUUpdate<EquiposDto>, UpdateEquipo>();
            builder.Services.AddScoped<ICUGetAllTelescopios<EquiposDto>, GetlAllTelescopios>();

            // Inyección de dependencia Casos de Uso Prestamos
            builder.Services.AddScoped<ICUAdd<PrestamoAltaDto>, AddPrestamo>();
            builder.Services.AddScoped<ICUGetById<PrestamoDto>, GetByIdPrestamo>();
            builder.Services.AddScoped<ICUGetById<IEnumerable<PrestamoDto>>, GetPrestamosByUserId>();
            builder.Services.AddScoped<ICUListadoPrestamosSocio<IEnumerable<PrestamoListadoDto>>, ListadoPrestamosSocio>();
            builder.Services.AddScoped<ICUUpdate<PrestamoDevolucionDto>, DevolverPrestamo>();
            builder.Services.AddScoped<ICUGetById<IEnumerable<EquiposDto>>, GetEquiposByPid>();
            builder.Services.AddScoped<ICUGetAuditoriaPrestamos<IEnumerable<LogPrestamoDto>>, GetAuditoriaPrestamos>();
            builder.Services.AddScoped<ICUGetAll<PrestamoDto>, GetAllPrestamos>();

            // Inyección de dependencia Casos de Uso Ranking Objetos Celestes
            builder.Services.AddScoped<ICUListadoRankingObjetosCelestes<IEnumerable<RankingObjetoCelesteDto>>, ListadoRankingObjetosCelestes>();
            builder.Services.AddScoped<ICUGetById<ObjetoDto>, GetByIdObjeto>();
            builder.Services.AddScoped<ICUGetAll<ObjetoDto>, GetAllObjetos>();

            // Inyección de dependencia Casos de Uso Obervaciones
            builder.Services.AddScoped<ICUAdd<ObservacionAltaDto>, AddObservacion>();
            builder.Services.AddScoped<ICUGetById<ObservacionAltaDto>, GetByIdObservacion>();


            // IA GORQ
            builder.Services.AddHttpClient<GroqEvaluacionService>();


            // Inyección de dependencia Contexto
            builder.Services.AddDbContext<StellarMindsContext>(); //cadena de conexión en appsettings.json

            // Inyección de dependencia Contexto con cadena de conexión hardcodeada
            //builder.Services.AddDbContext<StellarMindsContext>(
            //    option => option.UseSqlServer(builder.Configuration.GetConnectionString("StellarMindsContext"))
            //);

            // Middleware Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);

                options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese el token JWT"
                });

                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [
                        new OpenApiSecuritySchemeReference("bearer", document)
                    ] = []
                });
            });

            // Para darle seguridad a la API
            // 1. Obtener configuración JWT desde appsettings.json
            var jwtSection = builder.Configuration.GetSection("Jwt");
            builder.Services.Configure<JwtSettings>(jwtSection);
            var jwtSettings = jwtSection.Get<JwtSettings>();
            builder.Services.AddSingleton(jwtSettings);
            builder.Services.AddScoped<IJwtGenerator<UsuarioRol>, JwtGenerator>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);



            builder.Services.AddAuthentication(
                            options =>
                            {
                                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                            })
                          .AddJwtBearer(options =>
                          {
                              options.RequireHttpsMetadata = false; // ?? poner en true para producción
                              options.SaveToken = true;
                              options.TokenValidationParameters = new TokenValidationParameters
                              {
                                  ValidateIssuerSigningKey = true,
                                  IssuerSigningKey = new SymmetricSecurityKey(key),
                                  ValidateIssuer = false,   // podés poner en true si usás Issuer
                                  ValidateAudience = false, // podés poner en true si usás Audience
                              };
                          }
                       );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowMVC", policy =>
                {
                    policy.WithOrigins("http://localhost:5124") // puerto de tu MVC
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            var app = builder.Build();

            // Middleware Swagger
            app.UseSwagger();
            app.UseSwaggerUI();




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }


            app.UseHttpsRedirection();

            app.UseCors("AllowMVC");

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}