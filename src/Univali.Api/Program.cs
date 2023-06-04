using Univali.Api.Configuration;

// Criação do builder da aplicação
var builder = WebApplication.CreateBuilder(args);

// Configuração do servidor Kestrel para ouvir a porta 5000
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000);
});

// Adição de serviços ao contêiner de injeção de dependência
builder.Services.AddControllers(options =>
{
    // Inserção do JsonPatchInputFormatter no início da lista de input formatters
    options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
}).ConfigureApiBehaviorOptions(options =>
{
    // Supressão do filtro de ModelState inválido
    options.SuppressModelStateInvalidFilter = true;
});

// Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Construção da aplicação
var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    // Uso do Swagger UI e Swagger JSON no ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeamento dos controllers
app.MapControllers();

// Execução da aplicação
app.Run();
