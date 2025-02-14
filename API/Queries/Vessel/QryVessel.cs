namespace API;

public partial class APIQueries
{
    public static readonly Query Vessel = new()
    {
        APIBaseUri = APIList.Vessel.Description(),


        AdditionalAPI = new List<AdditionalAPIs>() {
            new(){
                APIMethod = HttpMethod.Post, APIRoute = AppSettings.GetValue("EmpezarAPIs:ReadRoute"),
                Delegate = async (Vessel param, IHttpClientFactory clientFactory, GoDB goDB, CancellationToken token) =>
                {
                    var retVal = await clientFactory.CreateClient("IPOS").PostAsJsonAsync<Vessel>(AppSettings.GetValue("IPOS:Vessel"), param, token);
                }
            }
        }
    };
}
