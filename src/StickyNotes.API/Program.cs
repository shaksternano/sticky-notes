using Microsoft.EntityFrameworkCore;
using Npgsql;
using StickyNotes.API.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Postgres")
                       ?? throw new InvalidOperationException("Postgres connection string is missing.");

builder.Services.AddSingleton<NpgsqlDataSource>(_ => NpgsqlDataSource.Create(connectionString));

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Development", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddDbContext<StickyNotesDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("StickyNotes")));

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseCors("Development");

app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
