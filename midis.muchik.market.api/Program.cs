using Microsoft.EntityFrameworkCore;
using midis.muchik.market.infrastructure.context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DBContext SQL Server
builder.Services.AddDbContext<MuchikContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MuchikConnection"));
});

builder.Services.AddTransient<MuchikContext>();

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
