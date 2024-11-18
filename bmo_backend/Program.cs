using bmo_backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o ApplicationDbContext ao serviço de injeção de dependência
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // Use `UseNpgsql` para PostgreSQL

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<MqttService>(); // Register MqttService as scoped
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
