using Microsoft.EntityFrameworkCore;
using StudentRegistrationAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
// New (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

// ✅ Required for Render to work
app.Run("http://0.0.0.0:8080");
