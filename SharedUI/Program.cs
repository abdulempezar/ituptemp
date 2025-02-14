using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Radzen;

namespace SharedUI;

public static class SharedUIServices
{
    /// <summary>
	/// Registers Shared UI Services to work with Application with customised actions
	/// </summary>
	/// <param name="services"></param>
	/// <param name="platform"></param>
	public static IServiceCollection AddSharedUI(this IServiceCollection services, SharedUIPlatform platform)
    {
        AppConsts.AppName = "ITUP";

        AppConsts.AzureADConfig.Authority = "https://login.microsoftonline.com/04c72f56-1848-46a2-8167-8e5d36510cbc";
        AppConsts.AzureADConfig.ClientId = "877ca977-a871-4efd-b888-572bfbbcb88b";
		AppConsts.AzureADConfig.RedirectUri = platform switch
		{
			SharedUIPlatform.MAUI => $"msal{AppConsts.AzureADConfig.ClientId}://auth",
			_ => "/authentication/login-callback",
		};

		AppConsts.APIClient.TimeoutInSec = 120;
#if DEBUG
		AppConsts.AzureADConfig.Authority = "https://login.microsoftonline.com/f5296e55-85a8-4ac9-a2da-a086439b04df";
        AppConsts.AzureADConfig.ClientId = "7c283d2c-507d-4f9f-add1-4e5e4135ec24";

		AppConsts.APIClient.APIBaseURL = "https://localhost:5001/api/";
        AppConsts.APIClient.AuthAPIKey = "a5f6d00888e217280d4baeebdf08e3a3831139948311399483113994832b623f84d5d2d880e99721212398e0c8";
        AppConsts.Environment = "Development";
        AppConsts.AzureADConfig.AuthenticationType = LoginAuthenticationTypes.AzureADAndAPI;
#else
        AppConsts.APIClient.APIBaseURL = "{APIBaseURL}";
        AppConsts.APIClient.AuthAPIKey = "{AuthAPIKey}";
        AppConsts.Environment = "{Environment}";
        AppConsts.AzureADConfig.AuthenticationType = {AuthenticationType};
#endif

		services.AddBlazorClient(platform);
		services.AddMudServices(config =>
		{
			config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.TopEnd;

			config.SnackbarConfiguration.PreventDuplicates = false;
			config.SnackbarConfiguration.NewestOnTop = true;
			config.SnackbarConfiguration.ShowCloseIcon = true;
			config.SnackbarConfiguration.VisibleStateDuration = 10000;
			config.SnackbarConfiguration.HideTransitionDuration = 500;
			config.SnackbarConfiguration.ShowTransitionDuration = 500;
			config.SnackbarConfiguration.SnackbarVariant = MudBlazor.Variant.Filled;
		});
		services.AddRadzenComponents();
        services.AddSingleton<IAppInfo, AppInfo>();

        return services;
    }
}

