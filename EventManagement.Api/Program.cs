using EventManagement.Application.Services;
using EventManagement.Infrastructure.Persistence;
using EventManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using EventManagement.Domain.Repositories;
using EventManagement.Application.Contracts.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
builder.Services.AddDbContext<EventManagementDbContext>(options =>
    options.UseSqlite("Data Source=EventManagement.db"));

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventServiceApp, EventServiceApp>();
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IResourceServiceApp, ResourceServiceApp>();
builder.Services.AddScoped<IResourceAssignmentRepository, ResourceAssignmentRepository>();
builder.Services.AddScoped<IResourceAssignmentServiceApp, ResourceAssignmentServiceApp>();


builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EventManagementDbContext>();
    SeedData.Initialize(dbContext);
}
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
