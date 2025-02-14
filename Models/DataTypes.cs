using System.Text.Json.Serialization;

namespace Models;

public enum TypeOfQuery { Raw, Summary, Count, Export, Grid }

[DapperJson(true)]
public class SysRoles
{
    public record Role(string role);
    public IEnumerable<Role> roles { get; set; }
}

[DapperJson(true)]
public class SysValueTypes
{
    public class SysValueType : EntityBase<SysValueType>
    {
        public string? code { get; set; }
        public string desc { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.Always)] public string displayvalue => $"{code} - {desc}";
	}

    public List<SysValueType> value { get; set; }
}
