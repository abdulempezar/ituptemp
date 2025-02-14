namespace Models;

[DapperJson(true)]
public class OtherLocDets
{
    public string address { get; set; }
    public string contact_person { get; set; }
    public string email_id { get; set; }
    public string region_code { get; set; }
    public string port_id { get; set; }
    public string tcs_terminal_id { get; set; }
    public bool is_custom_approve { get; set; }
    public string location_type { get; set; }
    public string is_truck_info_mandatory { get; set; }
    public string interface_code { get; set; }
    public int apms_yard_tmnl_no { get; set; }
    public string location_pod { get; set; }
}

public class Location : EntityBase<Location>
{
    public string location_ref_code { get; set; }
    public string location_name { get; set; }
    public OtherLocDets otherlocdets { get; set; }
}

