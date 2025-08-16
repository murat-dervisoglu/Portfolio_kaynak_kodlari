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

// Veritabaný baðlantýlarýný tanýmlýyoruz (Dependency Injection)
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

// HTTP baðlamýný kullanmak için
builder.Services.AddHttpContextAccessor();

// Session (oturum) ayarlarý
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120); // Oturum süresi
    options.Cookie.HttpOnly = true;                 // Sadece sunucu tarafýndan eriþilsin
    options.Cookie.IsEssential = true;              // GDPR gibi zorunlu durumlar için
});

// Cookie tabanlý kimlik doðrulama ayarlarý
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index"; // Giriþ yapýlmamýþsa yönlendirme
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(120); // Çerez geçerlilik süresi
        options.SlidingExpiration = true; // Her istekte süre uzasýn

        // Bu ayarlar canlý ortamda çerezlerin düzgün çalýþmasý için çok önemli
        options.Cookie.SecurePolicy = CookieSecurePolicy.None; // HTTPS zorunlu
        options.Cookie.SameSite = SameSiteMode.Lax;              // Chrome uyumu için
    });

// Yetkilendirme politikasý ekliyoruz
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireLoggedIn", policy =>
    {
        policy.RequireAuthenticatedUser(); // Giriþ yapýlmýþ kullanýcý zorunluluðu
    });
});

// Tüm controller'lar için varsayýlan yetkilendirme filtresi ekleniyor
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Eðer sunucu bir proxy (örn. Nginx, Cloudflare) arkasýndaysa, IP ve protokol doðru alýnsýn
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
});

// Hata sayfasý ayarlarý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseDeveloperExceptionPage(); // Bunu buraya EKLE
    app.UseHsts(); // HTTPS için zorunlu güvenlik baþlýðý
}

app.UseHttpsRedirection(); // Tüm trafiði HTTPS'e yönlendir
app.UseStaticFiles();      // wwwroot içeriðini sun

app.UseRouting();          // Controller yönlendirmesi

app.UseSession();          // Oturumlarý aktif et
app.UseAuthentication();   // Kimlik doðrulama mekanizmasýný aktif et
app.UseAuthorization();    // Yetkilendirme kontrolünü aktif et


// Varsayýlan route ayarý
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Page}/{action=Index}/{id?}");

app.Run();
