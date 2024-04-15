using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VideoGameOnlineShopApplication.Interfaces;
using VideoGameOnlineShopApplication.Models.Dto;
using VideoGameOnlineShopApplication.Services;
using VideoGameOnlineShopApplication.Validators;
using VideoGameOnlineShopDomain.Common;
using VideoGameOnlineShopDomain.DomainModels.Common.CodesTable;
using VideoGameOnlineShopDomain.Interfaces;
using VideoGameOnlineShopDomain.Interfaces.CodesTable;
using VideoGameOnlineShopDomain.Interfaces.Common;
using VideoGameOnlineShopDomain.Services;
using VideoGameOnlineShopInfrastructure;
using VideoGameOnlineShopInfrastructure.Repositories;
using VideoGameOnlineShopInfrastructure.Repositories.CodesTable;

var builder = WebApplication.CreateBuilder(args);

// Configure your services here
ConfigureServices(builder.Services);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// we will do this step AFTER we created our DbContext
// Context is the db context that we created.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VideoGameOnlineShopDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        // builder.WithOrigins(<insert ur frontend url here>, it accepts a string of array.)
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

// when implementing CORS, we need this, and make sure this is ABOVE UseRouting();
app.UseCors("MyPolicy");

app.UseRouting();

//app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.Run();


// ConfigureServices method
static void ConfigureServices(IServiceCollection services)
{
    // Dependency Injections 

    #region Services Dependency Injections

    services.AddScoped<IGameApplicationService, GameApplicationService>();
    services.AddScoped<IDeveloperApplicationService, DeveloperApplicationService>();
    services.AddScoped<ICodesTableApplicationService, CodesTableApplicationService>();

    services.AddScoped<IGameService, GameService>();
    services.AddScoped<IDeveloperService, DeveloperService>();

    #endregion

    #region Repository Dependency Injections

    services.AddScoped<IGameRepository, GameRepository>();
    services.AddScoped<IDeveloperRepository, DeveloperRepository>();
    services.AddScoped<ICodesTableRepository<CodeDecodeMatureRating>, CodesTableRepository<CodeDecodeMatureRating>>();
    services.AddScoped<ICodesTableRepository<CodeDecodeGenre>, CodesTableRepository<CodeDecodeGenre>>();
    services.AddScoped<ICodesTableRepository<CodeDecodePlatform>, CodesTableRepository<CodeDecodePlatform>>();

    #endregion

    #region Common Dependency Injections

    services.AddScoped<ICommonUtilityMethods, CommonUtilityMethods>();

    #endregion

    #region Validators

    services.AddScoped<IValidator<GameSubmissionDto>, GameSubmissionDtoValidator>();
    services.AddScoped<IValidator<GameUpdateDto>, GameUpdateDtoValidator>();
    services.AddScoped<IValidator<DeveloperSubmissionDto>, DeveloperSubmissionDtoValidator>();
    services.AddScoped<IValidator<DeveloperUpdateDto>, DeveloperUpdateDtoValidator>();

    #endregion
}