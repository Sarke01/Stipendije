using AplikacioniSloj.Servisi;
using DomenskiSloj;
using SlojPodataka.Interfejsi;
using SlojPodataka.Repozitorijumi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IKorisnikRepo>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var stringKonekcije = configuration.GetConnectionString("Stipendija");

    return new KorisnikRepo(stringKonekcije);
});

builder.Services.AddScoped<IStipendijaRepo>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var stringKonekcije = configuration.GetConnectionString("Stipendija");

    return new StipendijaRepo(stringKonekcije);
});

builder.Services.AddScoped<IZahtevRepo>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var stringKonekcije = configuration.GetConnectionString("Stipendija");

    return new ZahtevRepo(stringKonekcije);
});

builder.Services.AddScoped<KorisnikServis>();
builder.Services.AddScoped<StipendijaServis>();
builder.Services.AddScoped<ZahtevServis>();
builder.Services.AddScoped<PoslovnaPravila>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//app.UseHttpsRedirection();
//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Pocetna}");


//app.MapRazorPages();

app.Run();
