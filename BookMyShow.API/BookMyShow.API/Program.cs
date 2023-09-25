using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BookMyShow.Data;
using BookMyShow.API;
using Repository;
using BookMyShow.Services;
using BookMyShow.Services.Contracts;
using BookMyShow.Data.IRepositories;
using BookMyShow.Data.Repository;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using BookMyShow.DomainModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<BookMyShowDbContext>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("BookMyShowConnectionString")));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["RedisCachePortNumber"];
    options.InstanceName = "bookMyShow_";
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ITheatreService, TheatreService>();
builder.Services.AddScoped<ITheatreRepository, TheatreRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (httpContext, next) =>
{
    await next();
});

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError($"Something went wrong: {contextFeature.Error}");
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error."
            }.ToString());
        }
    });
});
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowOrigin");
app.UseAuthorization();
app.MapControllers();
app.Run();
