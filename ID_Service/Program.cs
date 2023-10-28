using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using ID_Service;
using ID_Service.Model;
using ID_Service.Profile_Service;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

//Add Identity
builder.Services.AddRazorPages();
builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.EmitStaticAudienceClaim = true;

}).AddTestUsers(User.Users)
  .AddInMemoryClients(Config.Clients)
  .AddInMemoryApiResources(Config.ApiResources)
  .AddInMemoryApiScopes(Config.ApiScopes)
  .AddInMemoryIdentityResources(Config.IdentityResources);
  //.AddProfileService<ProfileService>();
//List<Duende.IdentityServer.Models.Client> Clients = builder.Configuration.GetSection("Clients").Get<List<Duende.IdentityServer.Models.Client>>();
//Clients.Select(c => c.ClientSecrets.Select(e => { e.Value = e.Value.Sha256(); return e; }).ToList()).ToList();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication();
var app = builder.Build();

// add IdenitityServer in Pipeline 
app.UseIdentityServer();
//
//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
//app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

app.MapRazorPages();

//app.MapRazorPages().RequireAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    //endpoints.MapRazorPages(); // This one!
});
app.Run();
