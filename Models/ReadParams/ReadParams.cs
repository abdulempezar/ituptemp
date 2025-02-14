namespace Models;

public class FilterReadParams : ReadParams
{
    public string? orderby { get; set; } = null;
    public string? conditions { get; set; } = null;
}

public class UsersReadParams : ReadParams
{
    public string? mobno { get; set; } = null;
    public string? uname { get; set; } = null;
    public string? email { get; set; } = null;
    public string? urole { get; set; } = null;
    public string? dept { get; set; } = null;
    public string? apikey { get; set; } = null;
    public bool? isapplogin { get; set; } = null;
}

public class VesselReadParams : FilterReadParams
{

}