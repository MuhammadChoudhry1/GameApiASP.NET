using gamestore.api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Game Store API", Version = "v1" });
});

// Register custom services
builder.Services.AddScoped<IGameService, GameService>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Game Store API V1");
        c.RoutePrefix = "swagger"; // Makes Swagger UI available at /swagger
    });
}

app.UseCors();
app.UseHttpsRedirection();

// Serve static files from wwwroot
app.UseStaticFiles();

// Default route to serve index.html
app.MapGet("/", () => Results.Redirect("/index.html"));

app.UseAuthorization();
app.MapControllers();

// Welcome message
app.MapGet("/health", () => new { 
    Status = "Healthy", 
    Message = "Game Store API is running!", 
    Timestamp = DateTime.UtcNow,
    Endpoints = new[]
    {
        "GET /api/games - Get all games",
        "GET /api/games/{id} - Get game by ID",
        "POST /api/games - Create new game",
        "PUT /api/games/{id} - Update game",
        "DELETE /api/games/{id} - Delete game",
        "GET /swagger - API Documentation"
    }
});

app.Run();
