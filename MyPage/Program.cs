using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// MVC servisini ekliyoruz
builder.Services.AddControllersWithViews();

// Veritaban� ba�lant�lar�n� tan�ml�yoruz (Dependency Injection)
builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IEducationDal, EFEducationDal>();
builder.Services.AddScoped<IEducationService, EducationManager>();

builder.Services.AddScoped<IExperienceDal, EFExperinceDal>();
builder.Services.AddScoped<IExperienceService, ExperienceManager>();

builder.Services.AddScoped<ISkillsDal, EFSkillsDal>();
builder.Services.AddScoped<ISkillsService, SkillsManager>();

builder.Services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();
builder.Services.AddScoped<ISocialMediaService, SocialmediaManager>();

builder.Services.AddScoped<ITestimonialDal, EFTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonailManager>();

builder.Services.AddScoped<IFeatureDal, EFFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IPortfolioDal, EFPortfolioDal>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();

// HTTP ba�lam�n� kullanmak i�in
builder.Services.AddHttpContextAccessor();

// Session (oturum) ayarlar�
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120); // Oturum s�resi
    options.Cookie.HttpOnly = true;                 // Sadece sunucu taraf�ndan eri�ilsin
    options.Cookie.IsEssential = true;              // GDPR gibi zorunlu durumlar i�in
});

// Cookie tabanl� kimlik do�rulama ayarlar�
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Giri� yap�lmam��sa y�nlendirme
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(120); // �erez ge�erlilik s�resi
        options.SlidingExpiration = true; // Her istekte s�re uzas�n

        // Bu ayarlar canl� ortamda �erezlerin d�zg�n �al��mas� i�in �ok �nemli
        options.Cookie.SecurePolicy = CookieSecurePolicy.None; // HTTPS zorunlu
        options.Cookie.SameSite = SameSiteMode.Lax;              // Chrome uyumu i�in
    });

// Yetkilendirme politikas� ekliyoruz
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireLoggedIn", policy =>
    {
        policy.RequireAuthenticatedUser(); // Giri� yap�lm�� kullan�c� zorunlulu�u
    });
});

// T�m controller'lar i�in varsay�lan yetkilendirme filtresi ekleniyor
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// E�er sunucu bir proxy (�rn. Nginx, Cloudflare) arkas�ndaysa, IP ve protokol do�ru al�ns�n
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
});

// Hata sayfas� ayarlar�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseDeveloperExceptionPage(); // Bunu buraya EKLE
    app.UseHsts(); // HTTPS i�in zorunlu g�venlik ba�l���
}

app.UseHttpsRedirection(); // T�m trafi�i HTTPS'e y�nlendir
app.UseStaticFiles();      // wwwroot i�eri�ini sun

app.UseRouting();          // Controller y�nlendirmesi

app.UseSession();          // Oturumlar� aktif et
app.UseAuthentication();   // Kimlik do�rulama mekanizmas�n� aktif et
app.UseAuthorization();    // Yetkilendirme kontrol�n� aktif et


// Varsay�lan route ayar�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Page}/{action=Index}/{id?}");

app.Run();
