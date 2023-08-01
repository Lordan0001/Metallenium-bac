using Metall_Fest.models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Dep inj
builder.Services.AddDbContext<MainContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
    .AllowAnyOrigin() // ��������� ������� � ����� �������
    .AllowAnyHeader() // ��������� ��� ���������
    .AllowAnyMethod()); // ��������� ��� HTTP-������ (GET, POST, PUT, DELETE � �.�.)

app.UseAuthorization();

app.MapControllers();

app.Run();
