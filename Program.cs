using Microsoft.EntityFrameworkCore;
using TarefaFAcebookApi.Context;

var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext com a string de conexão "ConexaoPadrao"
builder.Services.AddDbContext<FacebookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

// Registrar controllers
builder.Services.AddControllers();

// Configurar CORS para liberar o frontend que está em http://127.0.0.1:5501
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5501")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Registrar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o Swagger apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Ativar CORS com a política antes da autorização e mapeamento de controllers
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
