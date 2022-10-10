using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Graph;

namespace Training;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();
        builder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });
        builder.Services.AddSingleton<IConfidentialClientApplication>(serviceProvider =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            return ConfidentialClientApplicationBuilder.Create(configuration[""])
                .WithClientSecret(configuration[""])
                .WithTenantId(configuration[""])
                .Build();
        });
        builder.Services.AddSingleton(serviceProvider =>
        {
            var authenticationProvider = serviceProvider.GetRequiredService<IAuthenticationProvider>();
            return new GraphServiceClient(authenticationProvider);
        });

        return builder.Build();
    }

}