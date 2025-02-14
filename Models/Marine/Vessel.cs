namespace Models;

public class Vessel : EntityBase<Vessel>
{
    public string vessel_name { get; set; }
    public long? intvslno { get; set; }
    public int tcs_terminal_no { get; set; }
    public string call_sign { get; set; }
    public string imo_nbr { get; set; }
    public OtherVesselDets otherdets { get; set; }
    [DapperJson(true)] public IEnumerable<HatchDets> hatchdets { get; set; }
    [DapperJson(true)] public IEnumerable<CraneDets> cranedets { get; set; }
    [DapperJson(true)] public UploadDocs vesseldocs { get; set; }
    [DapperJson(true)] public Vessel? vesselEdited { get; set; }
    public string? port_approved_flg { get; set; }
    public DateTime? port_approved_date { get; set; }
    public string? approved_by { get; set; }
    public string? rejremark { get; set; }
}

[DapperJson(true)]
public class OtherVesselDets
{
    public string? vesselshortname { get; set; }
    public string vessel_category { get; set; }
    public string vessel_sub_category { get; set; }
    public string vessel_clasification { get; set; }
    public string vessel_group { get; set; }
    public string line_code { get; set; }
    public string? governmentvessel_flg { get; set; }
    public string portofregister { get; set; }
    public string country_flag { get; set; }
    public string year_bult { get; set; }
    public string tpc { get; set; }
    public string loa { get; set; }
    public string vessel_beam { get; set; }
    public string depthmoulded { get; set; }
    public double vessel_height { get; set; }
    public double grt { get; set; }
    public double nrt { get; set; }
    public string reduce_grt_flg { get; set; }
    public double? reduce_grt { get; set; }
    public double? summer_dwt { get; set; }
    public double? summer_displacement_weight { get; set; }
    public double? max_dreft { get; set; }
    public string? light_vessel_free_board { get; set; }
    public double? parallel_body_length { get; set; }
    public double? bow_to_front_accomodation { get; set; }
    public double? bow_to_manifold_center { get; set; }
    public double? manifld_dist_fm_accom { get; set; }
    public string? wire_ropes_reqired_flg { get; set; }
    public double? dist_of_hatch_from_accom { get; set; }
    public double? bow_to_first_hatch { get; set; }
    public double? stern_lo_last_hatch { get; set; }
    public string? vessel_gearless_flag { get; set; }
    public string? vessel_work_area { get; set; }
    public double? no_of_main_engines_generator { get; set; }
    public string? size_of_main_engine { get; set; }
    public int? no_of_generators { get; set; }
    public double? generator_capacity { get; set; }
    public double? generator_fuel_cons_day { get; set; }
    public double? boiler_capacity { get; set; }
    public double? boiler_fuel_cons_day { get; set; }
    public double? bridge_to_stern { get; set; }
    public string? bow_thrust_capacity { get; set; }
    public double? total_teu_capacity { get; set; }
    public double? refer_teu_capacity { get; set; }
    public string? vessel_master_mailid { get; set; }
    public string? mmsi_no { get; set; }
    public string? inmarsat { get; set; }
    public string? remark { get; set; }
    public string? voa { get; set; }
    public DateTime? request_date { get; set; }
    public double? location_id { get; set; }
    public string? vessel_cd { get; set; }
    public string? apms_transfer_error_msg { get; set; }
    public string? apms_transfer_status { get; set; }
    public double? process_id { get; set; }
    public double? int_vsl_cd { get; set; }
    public double? dead_weight { get; set; }
    public double? vessel_dispmt { get; set; }
    public string? vsl_black_list_flg { get; set; }
    public string? ipos_err_msg { get; set; }
    public string? ipos_guid { get; set; }
    public bool? ipos_status { get; set; }
}

public class HatchDets
{
    public string hatch_type { get; set; }
    public string hatch_id { get; set; }
    public double height { get; set; }
    public double vessel_width { get; set; }
    public double vessel_length { get; set; }
    public double capacity { get; set; }
    public string? hatch_description { get; set; }
    public string imo { get; set; }
    public string int_vsl_cd { get; set; }
}

public class CraneDets
{
    public string crane_type { get; set; }
    public string crane_id { get; set; }
    public double? cycl_time { get; set; }
    public double? sf_wkld { get; set; }
    public double out_rch { get; set; }
    public string? grb_flg { get; set; }
    public double int_vsl_cd { get; set; }
    public string imo { get; set; }
}

