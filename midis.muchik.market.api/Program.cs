using midis.muchik.market.api.IoC;
using midis.muchik.market.api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMappgins();
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddDependencyContainer();

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseMiddleware<AuthorizationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
