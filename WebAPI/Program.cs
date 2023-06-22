using NLog;
using NLog.Web;
using WebAPI.Installers;
using WebAPI.Middelwares;

var logger = LogManager.Setup().LoadConfigurationFromFile("").GetCurrentClassLogger();

try
{
    #region Builder

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.InstallServicesInAssembly(builder.Configuration);

    builder.Logging.ClearProviders();

    builder.Host.UseNLog();

    #endregion

    var app = builder.Build();

    #region App

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
    }

    app.UseMiddleware<ErrorHandlingMiddelware>();

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

    #endregion
}
catch(Exception ex)
{
    logger.Fatal(ex, $"API stopped.{ex.Message}\n{ex.StackTrace}");
}
finally
{
    LogManager.Shutdown();
}




