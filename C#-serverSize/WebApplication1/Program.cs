using bll.functions;
using bll.interfaces;
using BLL.functions;
using BLL.interfaces;
using DaL.functions;
using DAl.interfaces;
using DAL;
using DAL.functions;
using DAL.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TripsContext>(options => options.UseSqlServer("Server=.;Database=Trip;TrustServerCertificate=True;Trusted_Connection=True;"));

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddScoped(typeof(IBookingDall), typeof(FBookingDall));
builder.Services.AddScoped(typeof(IBookingBll), typeof(fBookingBll));

builder.Services.AddScoped(typeof(IUserDall), typeof(fUserDall));
builder.Services.AddScoped(typeof(IUserBLL), typeof(fUserBll));

builder.Services.AddScoped(typeof(ITripDall), typeof(fTripDall));
builder.Services.AddScoped(typeof(ITripBll), typeof(fTripBll));

builder.Services.AddScoped(typeof(ITripsTypeDall), typeof(fTripTypeDall));
builder.Services.AddScoped(typeof(ITripsTypeBll), typeof(fTripTypeBll));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
    ;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
