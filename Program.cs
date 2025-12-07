using Microsoft.EntityFrameworkCore;
using Minecraft.AppDataContext;
using Minecraft.Services;

var builder = WebApplication.CreateBuilder(args);

// Lấy PORT từ Render (Render sẽ cung cấp biến môi trường PORT)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMinecraftGame, MinecraftGame>();

var app = builder.Build();

// Bật Swagger luôn (Render không có Development mode)
app.UseSwagger();
app.UseSwaggerUI();

// Render không hỗ trợ https → tắt HTTPS redirection
// app.UseHttpsRedirection();   // ❌ XÓA DÒNG NÀY

app.UseRouting();
app.MapControllers();

// Chạy app
app.Run();
