using Microsoft.Extensions.DependencyInjection;
using static Models.SysValueTypes;

namespace SharedUI;

public class AppInfo : IAppInfo
{
	private readonly IServiceProvider _serviceProvider;
	CancellationTokenSource? cancellationTokenSource;
	CancellationToken cancToken => (cancellationTokenSource ??= new()).Token;

	public Radzen.DialogOptions RadzenDialogOptions(string width = "700px") => new() { AutoFocusFirstElement = true, CloseDialogOnEsc = true, ShowTitle = false, Width = width, ShowClose = false };
	public MudBlazor.DialogOptions MudDialogOptions(MudBlazor.MaxWidth width) => new() { CloseOnEscapeKey = true, MaxWidth = width, FullWidth = true, CloseButton = true };


    public Lazy<ValueTask<IEnumerable<SysValueType>>> UserCompany { get; private set; }
    public Lazy<ValueTask<IEnumerable<SysValueType>>> UserLocation { get; private set; }
    public Lazy<ValueTask<IEnumerable<SysValueType>>> UserDepartment { get; private set; }
	public Lazy<ValueTask<IEnumerable<SysValueType>>> Company { get; private set; }
	public Lazy<ValueTask<IEnumerable<SysValueType>>> Location { get; private set; }
	public Lazy<ValueTask<IEnumerable<SysValueType>>> Department { get; private set; }
	public Lazy<ValueTask<IEnumerable<SysValueType>>> Budget { get; private set; }
	public Lazy<ValueTask<IEnumerable<SysValueType>>> BudgetType { get; private set; }
	public Lazy<ValueTask<IEnumerable<SysValueType>>> CapexType { get; private set; }
	public Lazy<ValueTask<IEnumerable<SysValueType>>> SecSubSecClause { get; private set; }
    public Lazy<ValueTask<IEnumerable<SysValueType>>> Section { get; private set; }
    public Lazy<ValueTask<IEnumerable<SysValueType>>> SubSection { get; private set; }
    public Lazy<ValueTask<IEnumerable<SysValueType>>> Clause { get; private set; }

    public AppInfo(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;	

		SetMasterData();
		SetLoginBased();
	}

	public void SetMasterData()
	{
		var _apiClient = _serviceProvider.GetRequiredService<APIClient>();
		Company = new(async () => (await _apiClient.Read<SysParams<SysValueTypes>>(APIList.SysParams.Description(), new SysParamsReadParams { systype = "company" }, cancToken))!.First().sysvalue.value.OrderBy(x => x.desc!), LazyThreadSafetyMode.PublicationOnly);
		Location = new(async () => (await _apiClient.Read<SysParams<SysValueTypes>>(APIList.SysParams.Description(), new SysParamsReadParams { systype = "location" }, cancToken))!.First().sysvalue.value.OrderBy(x => x.desc!), LazyThreadSafetyMode.PublicationOnly);
		Budget = new(async () => (await _apiClient.Read<SysParams<SysValueTypes>>(APIList.SysParams.Description(), new SysParamsReadParams { systype = "budget" }, cancToken))!.First().sysvalue.value.OrderBy(x => x.desc!), LazyThreadSafetyMode.PublicationOnly);
		BudgetType = new(async () => (await _apiClient.Read<SysParams<SysValueTypes>>(APIList.SysParams.Description(), new SysParamsReadParams { systype = "budgettype" }, cancToken))!.First().sysvalue.value.OrderBy(x => x.desc!), LazyThreadSafetyMode.PublicationOnly);
		CapexType = new(async () => (await _apiClient.Read<SysParams<SysValueTypes>>(APIList.SysParams.Description(), new SysParamsReadParams { systype = "capextype" }, cancToken))!.First().sysvalue.value.OrderBy(x => x.desc!), LazyThreadSafetyMode.PublicationOnly);
		SecSubSecClause = new(async () => (await _apiClient.Read<SysParams<SysValueTypes>>(APIList.SysParams.Description(), new SysParamsReadParams { systype = "secsubseccluse" }, cancToken))!.First().sysvalue.value.OrderBy(x => x.uin!), LazyThreadSafetyMode.PublicationOnly);
    }

	public void SetLoginBased()
	{
        var _apiClient = _serviceProvider.GetRequiredService<APIClient>();

        UserCompany = new(async () =>
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var authUser = scope.ServiceProvider.GetRequiredService<AuthenticateUsers>();
                var userCompany = (await authUser.GetJWTSecurityToken())?.JWTToken.Claims.First(x => x.Type == "Company").Value;
                var uc = string.IsNullOrWhiteSpace(userCompany) ? null : userCompany.Split(',');
                return (await Company.Value).Where(x => uc?.Contains(x.code!) ?? true);
            }
        }, LazyThreadSafetyMode.PublicationOnly);
    }
}
