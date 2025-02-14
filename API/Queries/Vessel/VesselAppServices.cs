using Dapper.SimpleSqlBuilder;
using Models;
using System.Security.Claims;

namespace API.Services;

public static class VesselAppServices
{
	public static Builder VesselQueryBuilder(VesselReadParams param, ClaimsPrincipal caller) {
        string valMsg = AppServices.ValidateApiCallParams(param);

        int loggedInUserId = Convert.ToInt32(caller.FindFirstValue(ClaimTypes.NameIdentifier));
        string loggedInUserName = caller.FindFirstValue(ClaimTypes.Name);

        string? company = caller.FindFirstValue("Company");
        string? plant = caller.FindFirstValue("Plant");
        string? request = caller.FindFirstValue("Request");
        string? process = caller.FindFirstValue("Process");
        var query = SimpleBuilder.Create().AppendNewLine($"");


		
		return query; 
	}
}
