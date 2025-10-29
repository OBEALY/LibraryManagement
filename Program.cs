using LibraryManagement.Middlewares;
using LibraryManagement.Repositories;
using LibraryManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Library Management API", Version = "v1" });
});

// Регистрация репозиториев и сервисов
builder.Services.AddSingleton<IAuthorRepository, AuthorRepository>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IAuthorService, AuthorService>();
builder.Services.AddSingleton<IBookService, BookService>();

var app = builder.Build();

// Глобальный обработчик исключений
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();