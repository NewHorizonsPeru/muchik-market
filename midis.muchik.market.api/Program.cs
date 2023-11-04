using Microsoft.EntityFrameworkCore;
using midis.muchik.market.application.interfaces;
using midis.muchik.market.application.mappings;
using midis.muchik.market.application.services;
using midis.muchik.market.domain.interfaces;
using midis.muchik.market.infrastructure.context;
using midis.muchik.market.infrastructure.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile));

//CommonContext SQL Server
builder.Services.AddDbContext<CommonContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MuchikMsSql"));
});

//SecurityContext MySQL
builder.Services.AddDbContext<SecurityContext>(opt =>
{
    opt.UseMySQL(builder.Configuration.GetConnectionString("MuchikMySql")!);
});

builder.Services.AddTransient<ICommonService, CommonService>();
builder.Services.AddTransient<IBrandRepository, BrandRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<CommonContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
