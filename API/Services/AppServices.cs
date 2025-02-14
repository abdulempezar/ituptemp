namespace API.Services;

public static class AppServices
{
    public static string ValidateApiCallParams(FilterReadParams param)
    {
        string valMsg = string.Empty;

        if ((param.orderby?.Contains(';') ?? false) || (param.orderby?.Contains("union", StringComparison.CurrentCultureIgnoreCase) ?? false)) valMsg = "Invalid value for orderby property";
        else if ((param.conditions?.Contains(';') ?? false) || (param.conditions?.Contains("union", StringComparison.CurrentCultureIgnoreCase) ?? false)) valMsg = "Invalid value for conditions property";
        else valMsg = "";

        return valMsg;
    }
}
