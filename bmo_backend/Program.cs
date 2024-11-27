using bmo_backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o ApplicationDbContext ao serviço de injeção de dependência
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Use `UseNpgsql` para PostgreSQL

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<MqttService>(); // Register MqttService as singleton

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Aplicar a política de CORS
app.UseCors("AllowAllOrigins");

app.MapControllers();

// Iniciar conexão com HiveMQ e inscrever nos tópicos
using (var scope = app.Services.CreateScope())
{
    var mqttService = scope.ServiceProvider.GetRequiredService<MqttService>();
    await mqttService.ConnectAsync();
    await mqttService.SubscribeAsync("compressor");
    await mqttService.SubscribeAsync("prensa");
}

app.Run();
