using Microsoft.EntityFrameworkCore;
using SeatManagementDataAccess.Context;
using SeatManagementDataAccess.Implementation;
using SeatManagementDomain.Repository;
using SeatManagementAPI.Services.Implementations;
using SeatManagementAPI.Services.Interfaces;
using SeatManagement.DataAccess.SeedData;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SeatManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SeatConnection")), ServiceLifetime.Singleton);

builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

builder.Services.AddSingleton<IAssetService, AssetService>();
builder.Services.AddSingleton<IBuildingService, BuildingService>();
builder.Services.AddSingleton<ICityService, CityService>();
builder.Services.AddSingleton<ICabinService, CabinService>();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IFacilityService, FacilityService>();
builder.Services.AddSingleton<ISeatService, SeatService>();
builder.Services.AddSingleton<IMeetingRoomService, MeetingRoomService>();
builder.Services.AddSingleton<IMeetingRoomAssetService, MeetingRoomAssetService>();
//builder.Services.AddSingleton<IReportService, ReportService>();






var app = builder.Build();

// Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var unitOfWork = services.GetRequiredService<IUnitOfWork>();
    var seedData = new SeedData(unitOfWork);
    seedData.Initialize();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
