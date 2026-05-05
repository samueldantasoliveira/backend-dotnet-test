var builder = WebApplication.CreateBuilder(args);

// Registra controllers na aplicação
builder.Services.AddControllers();

var app = builder.Build();

// Mapeia os controllers
app.MapControllers();

app.Run();