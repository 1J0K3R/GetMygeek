using GetMygeek.Components;
using GetMygeek.Data;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Ajouter l'injection de dépendance pour DatabaseService
string connectionStringDB = Environment.GetEnvironmentVariable("GetMyGeekDBConnectionString");

builder.Services.AddScoped<IDatabaseService>(sp =>
    new DatabaseService(connectionStringDB));//"Host=aws-0-eu-west-3.pooler.supabase.com;Username=postgres.wsvmdcvhflgudukhnull;Password=GetMyGeek@2024;Database=postgres"

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
