using Azure.Identity;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor.Services;
using WTR_Blazor.Components;
using WTR_Blazor.Data;
 

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Dodanie stanu autoryzacji
builder.Services.AddCascadingAuthenticationState();

// Konfiguracja autentykacji z Azure AD
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
    .EnableTokenAcquisitionToCallDownstreamApi(new[] { "User.Read" })
    .AddMicrosoftGraph(builder.Configuration.GetSection("GraphApi"))
    .AddInMemoryTokenCaches();

// Pobranie ?cie?ki do pliku bazy SQLite
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "Database", "todo.db");

// Konfiguracja zdarzeń OpenID Connect – przekierowanie po wylogowaniu
// Konfiguracja zdarzenia, które przekierowuje użytkownika po wylogowaniu
builder.Services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    // Przekierowanie po wylogowaniu
    options.Events.OnRedirectToIdentityProviderForSignOut = context =>
    {
        var postLogoutRedirectUri = builder.Configuration["AzureAd:PostLogoutRedirectUri"];
        // Skonstruuj URL wylogowania dla Azure AD z parametrem post_logout_redirect_uri
        var logoutUri = $"https://login.microsoftonline.com/{builder.Configuration["AzureAd:TenantId"]}/oauth2/v2.0/logout?post_logout_redirect_uri={Uri.EscapeDataString(postLogoutRedirectUri)}";
        context.Response.Redirect(logoutUri);
        context.HandleResponse();
        return Task.CompletedTask;
    };

    // Przekierowanie użytkownika na stronę /login
    options.Events.OnRedirectToIdentityProvider = context =>
    {
        // Jeśli żądanie nie pochodzi z /login ani nie jest już kierowane do MicrosoftIdentity/Account/SignIn,
        // przekierowujemy użytkownika na /login zamiast do Azure AD.
        if (!context.Request.Path.StartsWithSegments("/login", StringComparison.OrdinalIgnoreCase) &&
            !context.Request.Path.StartsWithSegments("/MicrosoftIdentity/Account/SignIn", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.Redirect("/login");
            context.HandleResponse();
        }
        return Task.CompletedTask;
    };
});

// Rejestracja HttpContextAccessor oraz klienta Graph
// Konfiguracja GraphServiceClient z Azure.Identity
builder.Services.AddSingleton<GraphServiceClient>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    // Pobranie wartości z appsettings.json
    var tenantId = configuration["AzureAd:TenantId"];
    var clientId = configuration["AzureAd:ClientId"];

    // Tworzenie interaktywnej przeglądarki do uwierzytelniania użytkownika
    var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions
    {
        TenantId = tenantId,
        ClientId = clientId,
        AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
    });

    return new GraphServiceClient(credential, new[] { "User.Read" });
});


// Dodanie widoków i kontrolerów potrzebnych dla Microsoft.Identity.UI
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));


builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 1024 * 1024 * 10; // 10MB
});


// (Opcjonalnie) konfiguracja autoryzacji
builder.Services.AddAuthorization(options =>
{
    // Dodaj polityki, jeśli potrzebujesz
    // By default, all incoming requests will be authorized according to the default policy.
    //options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();


// Database initialization if flag in appsettings.json is set to true
using (var scope = app.Services.CreateScope())
{
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    var shouldInitialize = configuration.GetValue<bool>("InitializeDatabase");
    await DbInitializer.Initialize(dbContextFactory, shouldInitialize);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Użycie autentykacji oraz autoryzacji
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllers();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
