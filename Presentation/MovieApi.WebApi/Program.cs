using Microsoft.EntityFrameworkCore;
using Persistence.Context;
// Eğer alttaki MovieContext hala kızarırsa üzerine tıklayıp Ctrl + . basarak using referansını ekle.

var builder = WebApplication.CreateBuilder(args);

// 1. Controller'ları sisteme dahil et
builder.Services.AddControllers();

// Veritabanı sınıfını sisteme tanıt
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbConnectionString")));

// 2. Swagger vitrinini oluşturacak servisleri sisteme kaydet
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Sadece geliştirme (Development) ortamında görsel Swagger arayüzünü (UI) aktif et
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();