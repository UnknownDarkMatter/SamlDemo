using FileExchange.Business.Interfaces;
using FileExchange.Business.Services;
using FileExchange.Common;
using FileExchange.Data.Database.EfCore6;
using FileExchange.Data.Database.Interfaces;
using FileExchange.Data.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using ITfoxtec.Identity.Saml2;
using ITfoxtec.Identity.Saml2.Schemas.Metadata;
using ITfoxtec.Identity.Saml2.MvcCore.Configuration;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

IdentityModelEventSource.ShowPII = true;

builder.Services.Configure<Saml2Configuration>(builder.Configuration.GetSection("Saml2"));

builder.Services.Configure<Saml2Configuration>(saml2Configuration =>
{
    saml2Configuration.AllowedAudienceUris.Add(saml2Configuration.Issuer);

    var entityDescriptor = new EntityDescriptor();
    entityDescriptor.ReadIdPSsoDescriptorFromUrl(new Uri(builder.Configuration["Saml2:IdPMetadata"]));
    if (entityDescriptor.IdPSsoDescriptor != null)
    {
        saml2Configuration.SingleSignOnDestination = entityDescriptor.IdPSsoDescriptor.SingleSignOnServices.First().Location;
        saml2Configuration.SignatureValidationCertificates.AddRange(entityDescriptor.IdPSsoDescriptor.SigningCertificates);
    }
    else
    {
        throw new Exception("IdPSsoDescriptor not loaded from metadata.");
    }
});

builder.Services.AddSaml2();

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddRazorPages((options) =>
{
    options.Conventions.AddPageRoute("/Index", "{*url}");
});

builder.Services.AddCors((options) =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins(builder.Configuration.GetValue<string>("CorsAllowedOrigin").Split(';'))
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddSwaggerGen();

switch (FileExchange.Common.Constants.DbProvider)
{
    case DbProviderEnum.PostGresSQL:
        {
            builder.Services.AddDbContext<FileExchangeDbContext>((option) =>
                option.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionPostGresSQL")));
            break;
        }
    case DbProviderEnum.SQLServer:
        {
            builder.Services.AddDbContext<FileExchangeDbContext>((option) =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionSQLServer")));
            break;
        }
    default:
        {
            throw new NotImplementedException(FileExchange.Common.Constants.DbProvider.ToString());
        }
}

builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFileService, FileService>();

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();

app.UseSaml2();

app.MapControllers();
app.MapRazorPages();


app.UseAuthentication();
app.UseAuthorization();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FileExchangeDbContext>();
    db.Database.Migrate();
}

app.Run();
