var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();



app.MapControllerRoute(
    name: "MP",
    pattern: "Home/MP",
    defaults: new { controller = "Home", action = "MyPage" });

app.MapControllerRoute(
    name: "MP2",
    pattern: "MP/{number}/{name},{other}",
    defaults: new { controller = "Home", action = "MyPage2" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Tool",
    pattern: "Tool/{controller=Tool}/{action=Index}/{id?}",
    defaults: new { controller = "Tool", action = "Index" });

app.MapControllerRoute(
    name: "Tool2",
    pattern: "Tool/Solve/{a}/{b}/{c}",
    defaults: new { controller = "Tool", action = "Solve2" });

app.MapControllerRoute(
    name: "Game",
    pattern: "Game/{controller=Game}/{action=Index}/{id?}",
    defaults: new { controller = "Game", action = "Index" });

app.MapControllerRoute(
    name: "Game2",
    pattern: "Set,{n}",
    defaults: new { controller = "Game", action = "Set" });

app.MapControllerRoute(
    name: "Game3",
    pattern: "Draw",
    defaults: new { controller = "Game", action = "Draw" });

app.MapControllerRoute(
    name: "Game4",
    pattern: "Guess,{n}",
    defaults: new { controller = "Game", action = "Guess" });

app.MapControllerRoute(
    name: "Game5",
    pattern: "SetDraw,{n}",
    defaults: new { controller = "Game", action = "SetDraw" });

app.MapControllerRoute(
    name: "Game6",
    pattern: "Set,{low},{high}",
    defaults: new { controller = "Game", action = "Set" });



app.Run();