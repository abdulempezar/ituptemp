using Microsoft.AspNetCore.Localization;
using System.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.AddEmpezarAPIs(true).AddAuthenticationAPIs<Users>((u, c) =>
{
	//c.Add(new Claim("Company", string.Join(',', (u.permission?.locationaccess ?? Enumerable.Empty<Locationaccess>()).Select(x => x.company))));
	//c.Add(new Claim("Location", string.Join(',', (u.permission?.locationaccess ?? Enumerable.Empty<Locationaccess>()).Select(x => x.location))));
	//c.Add(new Claim("Department", string.Join(',', (u.permission?.locationaccess ?? Enumerable.Empty<Locationaccess>()).SelectMany(x => x.department))));
	//c.Add(new Claim("Request", string.Join(',', (u.permission?.requestaccess ?? Enumerable.Empty<Requestaccess>()).Select(x => x.request))));
	//c.Add(new Claim("Process", string.Join(',', (u.permission?.requestaccess ?? Enumerable.Empty<Requestaccess>()).SelectMany(x => x.process))));
});

builder.Services.AddHttpClient("IPOS", client =>
{
	client.BaseAddress = new Uri(builder.Configuration.GetSection("IPOS:Path").Value);
	client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{AppSettings.GetValue("IPOS:UserName")}:{AppSettings.GetValue("IPOS:Password")}")));

	client.Timeout = TimeSpan.FromSeconds(Int32.Parse(AppSettings.GetValue("IPOS:TimeoutInSec")));
	client.DefaultRequestHeaders.Accept.Clear();
	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
}).SetHandlerLifetime(Timeout.InfiniteTimeSpan);//.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true });

//Register Services here
{
	//Masters
	builder.Services.AddScoped<IModule>(s => new Service<Users, UsersReadParams>(APIQueries.Users));

    //Tran
    builder.Services.AddScoped<IModule>(s => new Service<Vessel, UsersReadParams>(APIQueries.Vessel));

}

var app = builder.Build();
System.Globalization.CultureInfo[] supportedCultures = new[] {
	new System.Globalization.CultureInfo("en-IN")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
	DefaultRequestCulture = new RequestCulture("en-IN"),
	SupportedCultures = supportedCultures,
	SupportedUICultures = supportedCultures,
	RequestCultureProviders = new List<IRequestCultureProvider>
		{
			new QueryStringRequestCultureProvider(),
			new CookieRequestCultureProvider()
		}
});
app.UseEmpezarAPIs();

app.Run();
