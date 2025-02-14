using System.ComponentModel;

namespace Models;

public enum APIList
{
    [Description("")] Root,
    [Description("auth")] Authentication,
    [Description("users")] Users,
    [Description("sysparams")] SysParams,
    [Description("vessel")] Vessel,






    [Description("accounts")] AccountsAdmin,

	//LIQUID CONTROLLERS
	[Description("drybulkdo")] DryBulkDO,
	[Description("drybulkigm")] DryBulkIgm,
	[Description("drybulkpep")] DryBulkPEP,
	[Description("appeximdashboard")] AppEximDashboard,
	[Description("apptruckdashboard")] AppTruckDashboard,
	[Description("dopendency")] DoPendency,
	[Description("drybulkapptruckdashboard")] DryBulkAppTruckDashboard,
	[Description("igmapproval")] IgmApproval,
	[Description("igmprocessing")] IgmProcessing,
	[Description("importpep")] ImportPep,
	[Description("liquidipos")] LiquidIPOS,
	[Description("transport")] Transport,
	[Description("ulips")] Ulips,
}

public class APIRoutes
{
	//Account
	public const string VarifyOTP = "/VarifyOTP";
	public const string GetLoggedInDetails = "/GetLoggedInDetails";
	public const string GetFeatures = "/GetFeatures";
	public const string SaveAuditTimeStampAssist = "/SaveAuditTimeStampAssist";
	public const string getLocaionList = "/getLocaionList";
	public const string GetMobileNumber = "/getMobileNumber";
	public const string GetAllLanes = "/getAllLanes";
	public const string GetTruckCompDtls = "/getTruckCompDtls";
	public const string GetNewTruckDetails = "/getNewTruckDetails";
	public const string GetPermissions = "/getPermissions";
	public const string GetPermission = "/getPermission";
	public const string GetTypeAheadTruckNo = "/getTypeAheadTruckNo";
	public const string GetTruckDtls = "/getTruckDtls";
	public const string GetTruckCompartmentDetails = "/getTruckCompartmentDetails";
	// public const string GetNewTruckDetails = "/getNewTruckDetails";
	public const string GetAllITUTransporter = "/getAllITUTransporter";
	//public const string GetHelp = "/getHelp";
	public const string getTruckNosTypeAhead = "/getTruckNosTypeAhead";
	public const string GetAllUsers = "/getAllUsers";
	public const string GetUser = "/getUser";
	public const string GetUsers = "/getUsers";
	public const string GetUsersTypeAhead = "/getUsersTypeAhead";
	public const string GetTypeAheadTruckNoAll = "/getTypeAheadTruckNoAll";
	public const string GetAllLoggedInUsersCount = "/getAllLoggedInUsersCount";

	//Liquid
	public const string GetChangeOfOwner = "/getChangeOfOwner";
	public const string GetTankStock = "/getTankStock";
	public const string GetTruckDashboardData = "/getTruckDashboardData";
	public const string GetTruckByTruckNo = "/getTruckByTruckNo";
	public const string GetCustomDocListByIgm = "/getCustomDocListByIgm";
	public const string GetSummaryReport = "/getSummaryReport";
	public const string GetPepHdrIpos = "/getPepHdrIpos";
	public const string GetDoList = "/getdolist";
	public const string GetDoListDryBulkEnquiry = "/getdolistdrybulkenquiry";
	public const string GetDoListDryBulk = "/getDoListDryBulk";
	public const string GetTransporterDetails = "/gettransporterdetails";
	public const string GetTransporterDetailsDryBulk = "/gettransporterdetailsdrybulk";
	public const string GetDOWeightsDryBulk = "/getDOWeightsDryBulk";
	public const string GetIgmEntryDetails = "/getIgmEntryDetails";
	public const string GetVcnByHaulCd = "/getVcnByHaulCd";
	public const string GetDodetailsByIntentNo = "/getDodetailsByIntentNo";
	public const string GetPreIndentAppDtls = "/getPreIndentAppDtls";
	public const string GetPepExportById = "/getPepExportById";
	public const string GetExportPepByBLOrder = "/getExportPepByBLOrder";
	public const string GetTruckDetails = "/getTruckDetails";
	public const string GetPdfContent = "/getPdfContent";
	public const string GetSafetySurveyWebDashboard = "/getSafetySurveyWebDashboard";
	public const string GetDoDetailsByDoId = "/getDoDetailsByDoId";
	public const string GetDOWeights = "/getDOWeights";
	public const string GetCustomDocList = "/getCustomDocList";
	public const string GetDetailedBoe = "/getDetailedBoe";
	public const string GetDetailedStock = "/getDetailedStock";
	public const string GetTransporterMapper = "/getTransporterMapper";
	public const string GetFile = "/getFile";
	public const string GetIgmentryDetailsDryBulk = "/getIgmentryDetailsDryBulk";
}

public class SignalRHubs
{
    public const string GenHubs = "/hubs/genhubs";
}

public class GenHubCallBack
{
    public const string SyncTasks = "SyncTasks";
}

public class GenHubGroups
{
    public const string HubCallBack = "HubCallBack";
}
