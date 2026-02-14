using Microsoft.EntityFrameworkCore;
using AlhalabiShopping.Data;

var builder = WebApplication.CreateBuilder(args);

// إضافة خدمات MVC
builder.Services.AddControllersWithViews();

// ربط DbContext مع SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// إعدادات الجلسة (Session)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// استخدام الملفات الثابتة وRouting
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

// يبدأ التشغيل من صفحة Welcome
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Welcome}/{id?}"
);

app.Run();
