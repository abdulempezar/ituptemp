namespace Models;

[DapperJson(true)]
public class Permission
{
    public IEnumerable<UserLocations> locations { get; set; }

}

[DapperJson(true)]
public class OtherDetails
{
    public string user_type { get; set; }
    public string employee_id { get; set; }
    public DateTime last_login_date { get; set; }


    public string party_code { get; set; }
    
    public IEnumerable<string> ipos_container { get; set; }
    public string address { get; set; }
    public string pre_gate_user_id { get; set; }
    public string user_ip { get; set; }
    public string lane_addr { get; set; }
    public string payment_mapper { get; set; }
    public bool is_sez { get; set; }
    public string customer_id { get; set; }
    public string customer_ref_code { get; set; }
}

public class Users : EntityBase<Users>, IUsers
{
    public string mobno { get; set; }
    public string uname { get; set; }
    public string email { get; set; }
    public string apikey { get; set; }
    public bool isapplogin { get; set; }
    public Permission? permission { get; set; }
    public OtherDetails? otherdetails { get; set; }
    [DapperJson(true)] public IEnumerable<Roles> urole { get; set; }
    public string? lastotp { get; set; }
    public string? authenticatorkey { get; set; }
}

public class UserLocations
{
    public int locid { get; set; }
    public string tos_code { get; set; }
    public IEnumerable<string> permissions { get; set; }

}

